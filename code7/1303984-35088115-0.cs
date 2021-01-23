    void Update() {
        JumpLogic();
        movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
        movement *= Time.deltaTime;
        transform.position += movement;
    }
    //let the collider indicate to the player controller when
    //a collision occurs, then determine if this collision is relevant
    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.IsTouchingLayers(groundAbles))    
          isGrounded = true;
          
        // or do some other check using layers or tags ....
    }
    void JumpLogic()
    {
        if (isGrounded)
            currentJumps = 0;
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            GameObject newJumpSound = (GameObject)GameObject.Instantiate(jumpSound, (Vector2)transform.position, transform.rotation);
            GameObject newJumpEffect = (GameObject)GameObject.Instantiate(jumpEffect, (Vector2)transform.position - new Vector2(0, 0.25f), transform.rotation);
            GameObject.Destroy(newJumpEffect, 0.2f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            currentJumps++;
        }
    }
