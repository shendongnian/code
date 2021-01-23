    public class Path
    {
        public int ChildID { get; set; }
    }
    public class PathChildComparer : IEqualityComparer<Path>
    {
        public bool Equals(Path x, Path y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.ChildID == y.ChildID;
        }
        public int GetHashCode(Path obj)
        {
            return obj.ChildID;
        }
    }
