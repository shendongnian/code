    public sealed class NodeCoordinate : IEquatable<NodeCoordinate>
    {
        public float X { get; }
        public float Z { get; }
    
        public NodeCoordinate(float x, float z)
        {
            X = x;
            Z = z;
        }
        public override Equals(object other) => Equals(other as NodeCoordinate);
    
        public bool Equals(NodeCoordinate coord) =>
            coord != null && this.X == coord.X && this.Z == coord.Z;
    
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + X;
            hash = hash * 31 + Z;
            return hash;
        }
    
        public override string ToString() => $"Coodinate: {X} x {Z}";
    }
