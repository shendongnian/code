    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical;
    
        if (Input.GetAxisRaw("Vertical") > 0) 
        {
            moveVertical = Input.GetAxisRaw("Vertical");
        }
    
        rb.velocity = transform.forward * moveVertical * speed;
        transform.Rotate(0.0f, moveHorizontal * RotSpeed * Time.deltaTime, 0.0f);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        //rb.AddForce (transform.forward * Force);
    }
