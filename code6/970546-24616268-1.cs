    public class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        private IEqualityComparer<T> itemComparer;
        public SequenceComparer(IEqualityComparer<T> itemComparer = null)
        {
            this.itemComparer = itemComparer ?? EqualityComparer<T>.Default;
        }
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            unchecked
            {
                return obj.Aggregate(79, 
                    (hash, next) => hash * 39 + next.GetHashCode());
            }
        }
    }
