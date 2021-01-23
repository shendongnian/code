    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<T> obj)
        {
            //This works. But you might want to have a
            //better way for calculating the hash code
            return obj.Sum(x => x.GetHashCode());
        }
    }
