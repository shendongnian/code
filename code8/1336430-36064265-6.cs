    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);
        }
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            int index = 0;
            foreach (var item in collection)
                action(item, index++);
        }
    }
