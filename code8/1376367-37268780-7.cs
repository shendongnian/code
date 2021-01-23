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
            unchecked
            {
                // this returns 0 if obj is null
                // otherwise it combines the hashes of all elements
                // like hash = (hash * 397) ^ nextHash
                // if an array element is null its hash is assumed as 0
                // (this is the ReSharper suggestion for GetHashCode implementations)
                return obj?.Aggregate(0, (hash, o) => (hash * 397) ^ (o?.GetHashCode() ?? 0)) ?? 0;
            }
        }
    }
