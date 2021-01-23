    public static class Filters
    {
        public static IQueryable<T> IsActive<T>(this IQueryable<T> qry)
        {
            return qry.Where("Status = @0", 1);
        }
    }
