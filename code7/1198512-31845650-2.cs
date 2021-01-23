    class Camera
    {
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
    
        Vector2 centerOfScreen;// the current camera's lookAt in screen space (since the mouse coords are also in screen space)
        Vector3 lookAt;
    
        float cameraRotationSpeed;
    
    
    
        public Camera()
        {
            //initialize Projection matrix here
            //initialize view matrix here 
            //initialize centerOfScreen here like this:  new Vector2(screenWidth/2, screenHeihgt/2); 
            cameraRotationSpeed = 0.01f;//set to taste
        }
    
    
    
        public void Update(Vector3 playerPosition, MouseState currentMouse)
        {
            Matrix cameraWorld = Matrix.Invert(View);
    
            Vector2 changeThisFrame = new Vector2(currentMouse.X, currentMouse.Y) - centerOfScreen;
    
            Vector3 axis = (cameraWorld.Right * changeThisFrame.X) + (cameraWorld.Up * changeThisFrame.Y);//builds a rotation axis based on camera's local axis, not world axis
    
            float angle = axis.Length() * cameraRotationSpeed;
            axis.Normalize();
    
            //rotate the lookAt around the camera's position
            lookAt = Vector3.Transform(lookAt - playerPosition, Matrix.CreateFromAxisAngle(axis, angle)) + playerPosition;//this line does the typical "translate to origin, rotate, then translate back" routine
    
            View = Matrix.CreateLookAt(playerPosition, lookAt, Vector3.Up);// your new view matrix that is rotated per the mouse input
    
        }
    }
