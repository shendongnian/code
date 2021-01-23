    public static IQueryable<object> OrderByExtension(this IQueryable<object> source, string sortProperty, SortOrder sortOrder = SortOrder.Unspecified)
    {
        var sourceType = typeof(object);
        var underlyingType = source.First().GetType();
        var propertyType = underlyingType.GetProperty(sortProperty).PropertyType;
        var param = Expression.Parameter(sourceType);
        var body = Expression.Property(
            Expression.Convert(param, underlyingType), sortProperty
        );
        var lambda = Expression.Lambda(body, param);
        var sortMethod = sortOrder == SortOrder.Descending ? "OrderByDescending" : "OrderBy";
        var expr = Expression.Call(typeof(Queryable), sortMethod, new Type[] { sourceType, propertyType },
            source.Expression, lambda
        );
        return source.Provider.CreateQuery<object>(expr);
    }
