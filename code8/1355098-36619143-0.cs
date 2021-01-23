    private static readonly Type DbSetType = typeof(DbSet<>);
    private static IEnumerable<Type> GetAllEntityTypes(Type contextType)
    {
        return contextType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(p => p.PropertyType)
            .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == DbSetType)
            .Select(t => t.GetGenericArguments()[0]);
    }
