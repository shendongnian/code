    static Type GetTypeOfSummation<T1, T2>()
    {
        var p1 = Expression.Parameter(typeof(T1), "t1");
        var p2 = Expression.Parameter(typeof(T2), "t2");
        LambdaExpression x = DynamicExpression.ParseLambda(new[] { p1, p2 }, null, "t1 + t2");
        return x.Body.Type;
    }
