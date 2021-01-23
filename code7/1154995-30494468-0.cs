    public struct Rectangle
    {
        public static readonly Rectangle Empty = new Rectangle();
        private int x;
        private int y;
        private int width;
        private int height;
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Left
        {
            get { return X; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Top
        {
            get { return Y; }
        }
        ...
        ...
    }
