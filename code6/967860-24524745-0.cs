    public static class Extensions
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> qry, Func<T, string> field, string likeFilter)
        {
            return qry.Where(x => field(x).Contains(likeFilter));
        }
    }
