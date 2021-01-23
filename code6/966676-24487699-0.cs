    public static class MyExtentions
    {
        public static IOrderedQueryable<T> MyOrderBy<T, TKey>(this IQueryable<T> qry, Expression<Func<T, TKey>> expr)
        {
            return qry.OrderBy(expr);
        }
    }
