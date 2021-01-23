    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> qry, Expression<Func<T, string>> field, string likeFilter)
    {
        var member = field.Body as MemberExpression;
        var propInfo = member.Member as PropertyInfo;
        var param = Expression.Parameter(typeof(T), "x");
        var prop = Expression.Property(param, propInfo);
        var containsMethod = typeof(string).GetMethod("Contains");
        var body = Expression.Call(prop, containsMethod, Expression.Constant(likeFilter));
        var expr = Expression.Lambda<Func<T, bool>>(body, param);
        return qry.Where(expr);
    }
