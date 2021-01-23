    public struct Vector3Int : IEquatable<Vector3Int>
    {
        public int x,y,z;
    
        public bool Equals(Vector3Int other)
        {
           return  x == other.x && y == other.y && z == other.z;
        }
    
        public override int GetHashCode ()
        {
            return x^ (y <<5)^ (z << 5);
        }
        ....
