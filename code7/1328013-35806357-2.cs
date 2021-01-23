    public static class EnumerbleExtensions
    {
        public static HashSet<T> ToSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
    }
