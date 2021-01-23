    class Camera
    {
        public Matrix transform; // The transformed matrix
        public void Update(float rotation)
        {
            // you can add the positions here, x y z. Play around with it.
            // x should be half of the screen width,
            // y the half of the screen height, creating a "orgin" where it's rotating.
            transform = Matrix.CreateTranslation(0, 0, 0) * Matrix.CreateRotationZ(rotation);
        }
    }
