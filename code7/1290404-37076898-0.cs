    struct Vector
    {
        public long X;
        public long Y;
    }
    static class VectorExtension
    { 
        public static void AddToMe(this Vector v, long x, long y)
        {
            v.X += x;
            v.Y += y;
        }
        public static void AddToMe(this Vector v, Vector v2)
        {
            v.X += v2.X;
            v.Y += v2.Y;
        }
    }
