    public static class QueryableExtensions
    {
        public static IQueryable<T> ConditionalInclude<T>(this IQueryable<T> source, bool include) where T : YourType
        {
            if (include)
            {
                return source
                    .Include(a => a.Attachments)
                    .Include(a => a.Attachments.Owner));
            }
        
            return source;
        }
    }
