    public class Path
    {
        public int id{ get; set; }
    }
    public class MyComparer : IEqualityComparer<Path>
    {
        public bool Equals(Path x, Path y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.id== y.id;
        }
        public int GetHashCode(Path obj)
        {
            return obj.id;
        }
    }
