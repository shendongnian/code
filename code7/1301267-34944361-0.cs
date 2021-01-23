    public class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            var comparer = EqualityComparer<T>.Default;
            return x.SequenceEqual(y, comparer);
        }
        public int GetHashCode(IEnumerable<T> items)
        {
            unchecked
            {
                int hash = 17;
                foreach (T item in items)
                {
                    hash = hash * 23 + (item == null ? 0 : item.GetHashCode());
                }
                return hash;
            }
        }
    }
