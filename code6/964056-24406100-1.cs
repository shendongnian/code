    static Expression<Func<TEntity, bool>> Like<TEntity>(string propertyName, string queryText)
    {
        var parameter = Expression.Parameter(typeof (TEntity), "entity");
        var getter = Expression.Property(parameter, propertyName);
        //ToString is not supported in Linq-To-Entities, throw an exception if the property is not a string.
        if (getter.Type != typeof (string))
            throw new ArgumentException("Property must be a string");
        //string.Contains with string parameter.
        var stringContainsMethod = typeof (string).GetMethod("Contains", new[] {typeof (string)});
        var containsCall = Expression.Call(getter, stringContainsMethod,
            Expression.Constant(queryText, typeof (string)));
    
        return Expression.Lambda<Func<TEntity, bool>>(containsCall, parameter);
    }
