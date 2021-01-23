    if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    {
        var realSpeed = Input.GetButton("Sprint") ? runSpeed : speed;
        controller.Move (moveDirection * realSpeed * Time.deltaTime);
    }
    
