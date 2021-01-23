    public struct Point3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    public struct Vector3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);
        public Vector3D(Point3D p1, Point3D p2)
            : this(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z)
        {
        }
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Vector3D crossProduct(Vector3D left, Vector3D right)
        {
            double tmpX = 0, tmpY = 0, tmpZ = 0;
            tmpX = left.Y * right.Z - left.Z * right.Y;
            tmpY = left.Z * right.X - left.X * right.Z;
            tmpZ = left.X * right.Y - left.Y * right.X;
            return new Vector3D(tmpX, tmpY, tmpZ);
        }
        public static double dotProduct(Vector3D left, Vector3D right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }
    }
    public struct Plane3D
    {
        private const double TOLERANCE = 0.001;
        
        private readonly double independentTerm;
        public Vector3D Normal { get; }
        public Plane3D(Point3D p1, Point3D p2, Point3D p3)
        {
            Normal = Vector3D.crossProduct(new Vector3D(p1, p2), new Vector3D(p1, p3));
            if (Normal.Magnitude < TOLERANCE)
                throw new ArgumentException("Specified points do not define a valid plane.");
            independentTerm = -(Normal.X * p1.X + Normal.Y * p1.Y + Normal.Z * p1.Z);
        }
        public bool Contains(Point3D p) => Math.Abs(Normal.X * p.X + Normal.Y * p.Y + Normal.Z * p.Z + independentTerm) < TOLERANCE;
    }
