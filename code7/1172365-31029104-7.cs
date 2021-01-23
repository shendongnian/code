    public class EnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return Object.ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            // Implement a hash function for the collection here.
        }
    }
