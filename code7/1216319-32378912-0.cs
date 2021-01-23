    void Update() {
        // IF we are allowed to move.
        if(_PMS.canMove){
            // Get a -1, 0 or 1.
            moveHorizontal = Input.GetAxisRaw ("Horizontal");
            moveVertical = Input.GetAxisRaw ("Vertical");
        }
    }
    
    void FixedUpdate(){
        // IF we are allowed to move.
        if(_PMS.canMove){
            // Get Vector2 direction.
            movement = new Vector2(moveHorizontal * _PMS.invertXDirection, moveVertical * _PMS.invertYDirection);
            // Apply direction with speed.
            movement *= speed;
            // IF the user has an animation set.
            if(anim != null){
                // Play animations.
                Helper_Manager.PlayerAnimation(moveHorizontal, moveVertical, anim, _PMS); // always call this, assuming you play an idle animation if moveHorizontal and moveVertical are 0
            }
        
            // Apply the force for movement.
            rb.AddForce(movement);
        }
    }
