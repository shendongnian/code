    public class RegionComparer : IEqualityComparer<Region>
    {
        public bool Equals(Region x, Region y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Region obj)
        {
            return obj.Name.GetHashCode();
        }
    }
