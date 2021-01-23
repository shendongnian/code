    public static class CollectionExt
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> source)
        {
            Contract.Requires(collection != null);
            Contract.Requires(source != null);
            foreach (T item in source)
            {
                collection.Add(item);
            }
        }
    }
