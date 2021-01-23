    public static class Extension
    {
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            if (items == null)
            {
                return;
            }
            foreach (T item in items)
            {
                source.Add(item);
            }
        }
    }
