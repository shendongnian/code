    public static class EnumerableExtensionMethods
    { 
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach(T item in sequence) 
                action(item);
        }
    }
