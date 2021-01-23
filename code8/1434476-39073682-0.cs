    void onCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("GROUND")){
            isGrounded = true;
            Jumping = false;
            anim.SetInteger("Status", 0);
        }
    }
