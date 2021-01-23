                    //Rotate the character relative to the camera direction
                if (attackTimer <= 0 && moveDirection != Vector3.zero)
                {
                    var targetDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                    targetDirection = Camera.main.transform.TransformDirection(targetDirection);
                    targetDirection.y = 0.0f;
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                    float rotationSpeed = 100.0f;
                    Quaternion newRotation = Quaternion.Lerp(rbody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    
                    //Apply the rotation
                    rbody.MoveRotation(newRotation);
                }
                //Move the character
                if (IsMoving == true)
                {
                    
                    if (Input.GetAxis("Vertical") != 0) //Vertical movement (Up/Down)
                    {
                        if (attackTimer <= 0 || !IsGrounded)
                        {
                            rbody.AddForce(transform.forward * speed);
                        }
                    }
