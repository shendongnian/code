    public class NodeCoordinateComparer : IEqualityComparer<NodeCoordinate>
    {
        public bool Equals(NodeCoordinate a, NodeCoordinate b)
        {
            return (a.x == b.x && a.z == b.z);
        }
    
        public int GetHashCode(NodeCoordinate coord)
        {
            return string.Format("{0}x{1}", coord.x, coord.z).GetHashCode();
        }
    
    
    }
