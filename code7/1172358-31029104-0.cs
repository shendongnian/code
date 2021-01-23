    class CollectionComparer<TItem> : IEqualityComparer<ICollection<TItem>>
    {
        public bool Equals(ICollection<TItem> x, ICollection<TItem> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(ICollection<TItem> obj)
        {
            return obj.GetHashCode();
        }
    }
