    public class MyComparer : IEqualityComparer<object[]>
    {
        public bool Equals(object[] x, object[] y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null) || x.Length != y.Length) return false;
            return x.Zip(y, (a, b) => a == b).All(c => c);
        }
        public int GetHashCode(object[] obj)
        {
            return obj?.Aggregate(0, (hash, o) => (hash * 391) ^ (o?.GetHashCode() ?? 0)) ?? 0;
        }
    }
