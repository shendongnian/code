    public static class EnumerableExtensions
    {
        public static bool AllUnique<TSource, TResult>(this IEnumerable<TSource> enumerable, 
            Func<TSource, TResult> selector)
        {
            var uniques = new HashSet<TResult>();
            return enumerable.All(item => uniques.Add(selector(item)));
        }
    }
