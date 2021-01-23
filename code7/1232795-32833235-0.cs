    public class NameComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (y.Contains(x))
                return true;
            return false;
        }
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
