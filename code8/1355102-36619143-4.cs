    private static readonly MethodInfo CreateObjectSetMethodInfo = typeof(ObjectContext).GetMethod("CreateObjectSet", new Type[0]);
    private static readonly Type CollectionType = typeof(ICollection<>);
    private static IEnumerable<PropertyInfo> GetNavigationProperties(DbContext context, Type entityType)
    {
        var objectContext = ((IObjectContextAdapter)context).ObjectContext;
        var createObjectSetMethod = CreateObjectSetMethodInfo.MakeGenericMethod(entityType);
        var entity = createObjectSetMethod.Invoke(objectContext, new object[0]);
    
        var entitySet = (EntitySet)entity.GetType().GetProperty("EntitySet").GetValue(entity);
        var elementType = entitySet.ElementType;
        return elementType.NavigationProperties.Select(p => entityType.GetProperty(p.Name))
            // Filter Properties that are of type ICollection
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == CollectionType);
    }
