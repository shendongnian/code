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
                const double Eps = 1e-6;
                double D = X * X + Y * Y;
                if (D >= 1.0 - Eps && D <= 1.0 + Eps) {
                    return 1.0f;
                } else {
                    return (float)Math.Sqrt(D);
                }
            }
        }
        public override string ToString()
        {
            return $"Vector({X}, {Y})";
        }
    }
