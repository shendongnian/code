    if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetButton("Sprint")){
        controller.Move (moveDirection * runSpeed * Time.deltaTime);
    } 
    else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
        controller.Move (moveDirection * speed * Time.deltaTime);
    }
