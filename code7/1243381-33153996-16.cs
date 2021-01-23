    public static class CollectionExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate).AsQueryable();
            else
                return source;
        }
    }
