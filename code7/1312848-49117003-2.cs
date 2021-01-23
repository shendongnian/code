    public static class MyTableExtensions
    {
        public static IQueryable<TEntity> FilterMyTablesByName<TEntity>(
            this IQueryable<TEntity> query, string[] names)
            where TEntity : class, IMyTable
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            if (!names.Any() || names.All(string.IsNullOrWhiteSpace))
            {
                return query; // Unmodified
            }
            // Modified
            return query.Where(x => names.Contains(x.Name));
        }
        // Replicate per array/filter...
    }
