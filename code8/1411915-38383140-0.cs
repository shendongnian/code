    public static class LINQToObjectExtensions
    {
        public static void UpdateAll<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
