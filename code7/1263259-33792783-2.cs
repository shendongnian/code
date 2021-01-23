    public class TextureRegion2D
    {
        public Texture2D Texture { get; protected set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle Bounds { get { return new Rectangle(X, Y, Width, Height); } }
    }
