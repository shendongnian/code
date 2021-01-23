    public static class LinqExtensions
    {
        public static bool ContainsMultiple<T>(this IEnumerable<T> enumerable, T item)
        {
            bool seen = false;
            foreach (T t in enumerable)
            {
                if (t.Equals(item))
                {
                    if (seen) return true;
                    else seen = true;
                }
            }
            return false;
        }
    }
