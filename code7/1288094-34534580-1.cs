    bool jumping = false;
    // User Input
    void Update ()
    {
        xDir = Input.GetAxis ("Horizontal") * moveSpeed;
    
        if (jumping)
        {
            // Process jumping here
            if (/* Check for jumping finished here */)
            {
                // Finished jumping
                jumping = false;
            }
        }
        else if (xDir > 0)
        {
            goalRotation = Quaternion.Euler (0, 0, 0);
            SetAnimation ("Walk", true);
    
            if (Input.GetKeyDown("space"))
            {
                SetAnimation ("Walk-Jump", true);
                jumping = true;
            }
        } 
        else if (xDir < 0)
        {
            goalRotation = Quaternion.Euler (0, 180, 0);
            SetAnimation ("Walk", true);
    
            if (Input.GetKeyDown("space"))
            {
                SetAnimation ("Walk-Jump", true);
                jumping = true;
            }
        }
        else
        {
            SetAnimation ("Idle", true);
    
            if (Input.GetKeyDown("space"))
            {
                SetAnimation ("Idle-Jump", true);
                jumping = true;
            }
        }
    
        graphics.localRotation = Quaternion.Lerp (graphics.localRotation, goalRotation, rotateSpeed * Time.deltaTime);
    }
