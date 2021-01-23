    public class StateComparer : IEqualityComparer<Location>
    {
        public bool Equals(Location x, Location y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return Equals(x.State, y.State);
        }
    
        public int GetHashCode(Location obj)
        {
            if (ReferenceEquals(obj, null))
                return 0;
            if (ReferenceEquals(obj.State, null))
                return 0;
            return obj.State.GetHashCode();
        }
    }
