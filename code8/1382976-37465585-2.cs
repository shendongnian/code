    public struct Vector
    {
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; }
        public int Y { get; }
        
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public float Magnitude
        {
            get
            {
                int d = X * X + Y * Y;
                if (d == 1 || d == 0) {
                    return d;
                } else {
                    return (float)Math.Sqrt(d);
                }
            }
        }
        public override string ToString()
        {
            return $"Vector({X}, {Y})";
        }
    }
