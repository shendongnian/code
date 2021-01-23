    public static IQueryable<T> RetrieveAll<T>(params Expression[] eagerProperties)
    {
        var type = typeof(T);
        var entitySet = ResolveEntitySet(type);
        var query = context.CreateQuery<T>(entitySet);
        foreach (var e in eagerProperties)
        {
            query = query.Expand(e);
        }
        var account = type.GetProperty("AccountId");
        if (account != null)
        {
            Guid g = new Guid("3252353h....");
            var parameter = Expression.Parameter(type);
            var property = Expression.Property(parameter, account);
            var guidValue = Expression.Constant(g);
            var lambdaPredicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(property, guidValue), parameter);
            return query.Where(lambdaPredicate);
        }
        return query;
    }
