    public class UnorderedEnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.OrderBy(i => i).SequenceEqual(y.OrderBy(i => i));
        }
        // Just the count of the array, 
        // it violates the rule of hash code but should be fine here
        public int GetHashCode(IEnumerable<T> obj)
        {
            return obj.Count();
        }
    }
