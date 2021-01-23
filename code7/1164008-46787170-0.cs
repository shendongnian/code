    public IEnumerable<TReturn> GetAll<TReturn>(
        Expression<Func<TEntity, TReturn>> selectExp,
        string orderColumnName,
        Boolean descending,
        params Expression<Func<TEntity, Object>>[] includeExps)
    {
        var entityType = typeof(TEntity);
        var prop = entityType.GetProperty(orderColumnName);
        var param = Expression.Parameter(entityType, "i");
        var orderExp = Expression.Lambda(
            Expression.MakeMemberAccess(param, prop), param);
        // get the original GetAll method overload
        var method = this.GetType().GetMethods().Where(m => m.Name == "GetAll" && m.GetGenericArguments().Length == 2);
        var actualMethod = method.First().MakeGenericMethod(typeof(TReturn), prop.PropertyType);
        return (IEnumerable<TReturn>)actualMethod.Invoke(this, new object[] { selectExp, orderExp, descending, includeExps });
    }
