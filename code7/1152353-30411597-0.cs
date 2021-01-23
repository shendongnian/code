    public static IQueryable<TSource> OrderByPropertyDescending<TSource>(IQueryable<TSource> source, string propertyName)
    {
        var sourceType = typeof (TSource);
        var parameter = Expression.Parameter(sourceType, "item");
        var propertyInfo = FindMyProperty(sourceType, propertyName);
        var orderByProperty = Expression.Property(parameter, propertyInfo);
        var orderBy = Expression.Lambda(orderByProperty, new[] { parameter });
        return Queryable.OrderByDescending(source, (dynamic) orderBy);
    }
    private PropertyInfo FindMyProperty(Type type, string propertyName)
    {
        return type.GetProperty(propertyName);
    }
