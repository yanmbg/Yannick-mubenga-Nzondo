using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 9f;
    public GameObject pauseMenu;
    public float rotationSpeed = 700f;
    private Rigidbody rb;
    private bool isGrounded;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

         if (Input.GetKeyDown(KeyCode.Escape))
        {
        TogglePause();
        }
    }

     void Rotate()
    {
        float rotationDirection = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationDirection, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        } 
    }
  
    void TogglePause()
     {
    pauseMenu.SetActive(!pauseMenu.activeSelf);
    Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
     }
  

}
