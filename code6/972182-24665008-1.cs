    void Update () {
        Vector3 vel = new Vector3();
        
        if(Input.GetKey(Up)){
            Debug.Log("UP");
            Vector3 velUp = new Vector3();
            // just use 1 to set the direction.
            velUp.y = 1;
            vel += velUp;
        }
        else if(Input.GetKey(Down)){
            Vector3 velDown = new Vector3();
            velDown.y = -1;
            vel += velDown;
        }
        
        // no else here. Combinations of up/down and left/right are fine.
        if(Input.GetKey(Left)){
            Vector3 velLeft = new Vector3();
            velLeft.x = -1;
            vel += velLeft;
        }
        else if(Input.GetKey(Right)){
            Vector3 velRight = new Vector3();
            velRight.x = 1;
            vel += velRight;
        }
        // check if player wants to move at all. Don't check exactly for 0 to avoid rounding errors
        // (magnitude will be 0, 1 or sqrt(2) here)
        if (vel.magnitude > 0.001) {
          Vector3.Normalize(vel);
          vel *= walkSpeed;
          rigidbody2D.velocity = vel;
        }
        
        //rotation
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
