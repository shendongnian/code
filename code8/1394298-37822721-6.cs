    public static class ExtensionMethods
    {
        public static bool TryFirst<T>(this IEnumerable<T> @this, Func<T, bool> predicate, out T result)
        {
            foreach (var item in @this)
            {
                if (predicate(item))
                {
                    result = item;
                    return true;
                }
            }
            result = default(T);
            return false;
        }
    }
