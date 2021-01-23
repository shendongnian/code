    namespace WindowsGame1
    {
        class FPSCamera
        {
            public Matrix View;
            public Matrix Proj;
            public Vector3 Position, Target;
    
    
            public FPSCamera(float aspect)
            {
                
                Proj = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect, 1f, 1000f);
                Target = Vector3.Forward;
                SetViewMatrix();
            }
    
            public void UpdateCameraByPitchYawTranslation(float amountToPitchThisFrame, float amountToYawThisFrame, Vector3 amountToTranslateThisFrame)
            {
                Position += amountToTranslateThisFrame;
                Target += amountToTranslateThisFrame;
    
                Matrix camera = Matrix.Invert(View);
                Target = Vector3.Transform(Target - Position, Matrix.CreateFromAxisAngle(camera.Right, amountToPitchThisFrame)) + Position;
                Target = Vector3.Transform(Target - Position, Matrix.CreateFromAxisAngle(camera.Up, amountToYawThisFrame)) + Position;
    
                SetViewMatrix();
            }
    
            public void SetCameraToLookAtSpecificSpot(Vector3 spotToLookAt)
            {
                Target = spotToLookAt;
                SetViewMatrix();
            }
    
            private void SetViewMatrix()
            {
                View = Matrix.CreateLookAt(Position, Target, Vector3.Up);
            }
    
        }
    }
