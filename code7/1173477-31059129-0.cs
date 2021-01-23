    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static Vector operator -(Vector a, Vector b)
        {
            Vector v = new Vector();
            v.X = a.X - b.X;
            v.Y = a.Y - b.Y;
            return v;
        }
    }
