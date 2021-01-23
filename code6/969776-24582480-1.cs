    public class Vector3d
    {
        public readonly double X, Y, Z;
        public Vector3d(double x, double y, double z)
        {
            X=x; Y=y; Z=z;
        }
        public double Dot(Vector3d other)
        {
            return X*other.X + Y*other.Y + Z*other.Z;
        }
        public UnitVector3d Normalize()
        {
            return UnitVector3d.FromVector(this);
        }
        /* More operators like Times and Length, plus Equals and GetHashCode here */
    }
    public class UnitVector3d : Vector3d
    {
        private UnitVector3d (double x, double y, double z) : base(x, y, z)
        {
            /* General constructor. Private so it can only be called by trusted
               functions because it could be used to construct non-unit UnitVectors */
        }
        public static UnitVector3d FromVector(Vector3d vec)
        {
            Vector3d normalized = vec.Times(1.0/vec.Length());
            return new UnitVector3d(normalized.X, normalized.Y, normalized.Z);
        }
    }
