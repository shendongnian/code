    public struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        // In C#6, the "private set;" can be removed
        public int X { get; private set; }
        public int Y { get; private set; }
    }
