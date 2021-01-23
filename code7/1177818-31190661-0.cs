    public static Expression<Func<T, TResult>> CreateSelector<T, TResult>(
        string memberName)
    {
        var param = Expression.Parameter(typeof(T));
        var body = Expression.PropertyOrField(param, memberName);
        return Expression.Lambda<Func<T, TResult>>(body, param);
    }
