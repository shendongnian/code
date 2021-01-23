    public static Func<TEntity, bool> GetComparer<TEntity,TProperty>(
        Expression<Func<TEntity,TProperty>> selector, TProperty value)
    {
        var propertyRef = selector.Body;
        var parameter = selector.Parameters[0];
        var constantRef = Expression.Constant(value);
        var comparer 
            = Expression.Lambda<Func<TEntity, bool>>
                (Expression.Equal(propertyRef, constantRef), parameter)
                .Compile();
        return comparer;
    }
