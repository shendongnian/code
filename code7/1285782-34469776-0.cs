    public static class ContextExtensions
    {
        public static IEnumerable<IQueryable> GetAllDbSets(this DbContext context)
        {
            return context.GetType()
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType
                            && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => (IQueryable)p.GetValue(context));
        }
    }
