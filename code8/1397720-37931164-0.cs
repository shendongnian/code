    public class MovieComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            return x == y;
        }
        public int GetHashCode(string obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.GetHashCode();
        }
    }
