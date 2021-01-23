    public class Point3_
    {
        // Converts a Point3 to Point3_ by explicit casting
        public static explicit operator Point3_(Point3 p)
        {
            return new Point3_(p.X, p.Y, p.Z);
        }
    }
