using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr142_isWalking : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private bool facingRight = true;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = speed * moveInput;

        //setup anim
        if(moveInput.x == 0 && moveInput.y == 0){
            anim.SetBool("isWalking", false);
        }else{
            anim.SetBool("isWalking", true);
        }

        //flip character left or right
        if(moveInput.x > 0 && !facingRight || moveInput.x < 0 && facingRight){
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
