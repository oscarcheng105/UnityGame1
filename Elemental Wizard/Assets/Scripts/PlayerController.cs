using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput>0 && facingRight == false){
            Flip();
        }
        else if (moveInput<0 && facingRight == true){
            Flip();
        }

        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
        /*Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;*/
    }   
}
