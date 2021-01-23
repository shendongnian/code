    public class UsersComparer : IEqualityComparer<clsEntity>
    {
        public bool Equals(clsEntity x, clsEntity y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.ID == y.ID; // or whatever you use to determine equality
        }
        public int GetHashCode(clsEntity x)
        {
            if (Object.ReferenceEquals(x, null)) return 0;
            return x.ID.GetHashCode();
        }
    }
