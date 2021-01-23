    public static IEnumerable<PropertyInfo> GetICollectionProperties(object entity) 
    {
        return entity.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType
                && p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));
    }
