    public static class MyLinqExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Boolean condition, System.Linq.Expressions.Expression<Func<T, Boolean>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Boolean condition, Func<T, Boolean> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    }
