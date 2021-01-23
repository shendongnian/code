    public static Expression<Func<TFirstParam, TResult>>
        Combine<TFirstParam, TIntermediate, TResult>(
        this Expression<Func<TFirstParam, TIntermediate>> first,
        Expression<Func<TFirstParam, TIntermediate, TResult>> second)
    {
        var param = Expression.Parameter(typeof(TFirstParam), "param");
        var newFirst = first.Body.Replace(first.Parameters[0], param);
        var newSecond = second.Body.Replace(second.Parameters[0], param)
            .Replace(second.Parameters[1], newFirst);
        return Expression.Lambda<Func<TFirstParam, TResult>>(newSecond, param);
    }
