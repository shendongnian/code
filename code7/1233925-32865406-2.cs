    public class DictComparer : IEqualityComparer<Dictionary<string, string>>
    {
        public bool Equals(Dictionary<string, string> x, Dictionary<string, string> y)
        {
            return (x == y) || (x.Count == y.Count && !x.Except(y).Any());
        }
        public int GetHashCode(Dictionary<string, string> x)
        {
            return x.GetHashCode();
        }
    }
