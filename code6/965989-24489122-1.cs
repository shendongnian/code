    public class Cube
    {
        public Vector3 Position { get; set; }
        public Texture2D Texture { get; set; }
        
        public Cube(Vector3 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }
    
        public void Draw(GraphicsDevice device)
        {
            var vertices = createCubeTexture(position);
            device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 2, VertexPositionTexture.VertexDeclaration);
        }
    }
