    public static class Extensions
    {
        public static IList<T> GetList<T>(this IQueryable<T> query)
        {
            return query.ToList();
        }
    }
