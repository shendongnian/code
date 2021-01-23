    public class StringArrayEqualityComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            return x.OrderBy(z => z).SequenceEqual(y.OrderBy(z => z));
        }
        public int GetHashCode(string[] obj)
        {
            return obj.GetHashCode();
        }
    }
