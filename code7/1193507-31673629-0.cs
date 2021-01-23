     public static class DictionaryExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> method)
        {
            foreach (T obj in enumerable)
            {
                method(obj);
            }
        }
    }
