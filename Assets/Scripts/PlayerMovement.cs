using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 newPosition = new Vector3(50, 5, 0);
    public Rigidbody2D rBody;
    public SpriteRenderer render;

    private float inputHorizontal;
    public float movementSpeed = 6;
    public float jumper = 13;
    public GroundSensor sensor;

    void Awake(){
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        inputHorizontal = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && sensor.isGrounded) {
            rBody.AddForce(new Vector2(0,1) * jumper, ForceMode2D.Impulse);
        }
        
        if(inputHorizontal < 0){
            render.flipX = true;  
        }
        else if(inputHorizontal > 0){
            render.flipX = false; 
        }
    }
      void FixedUpdate(){
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y); 
    }

}
