        private void FixedUpdate()
        {
    if (paused != true){
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            character.Move(1, false, jump);
            jump = false;
    }
        }
