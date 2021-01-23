    public class TextureRegion2D
    {
        public TextureRegion2D(string name, Texture2D texture, int x, int y, int width, int height)
        {
            if (texture == null) throw new ArgumentNullException("texture");
            Name = name;
            Texture = texture;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public string Name { get; private set; }
        public Texture2D Texture { get; protected set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }
    }
