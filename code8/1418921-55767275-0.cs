    public class Vector
    {
        // ...
        public static readonly IEqualityComparer<Vector> ComparerForDictionaries
            = new VectorComparer();
        private class VectorComparer : IEqualityComparer<Vector>
        {
            public bool Equals(Vector v1, Vector v2)
            {
                return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
            }
            public int GetHashCode(Vector v)
            {
                return (v.x, v.y, v.z).GetHashCode(); // using a ValueTuple
            }
        }
    }
