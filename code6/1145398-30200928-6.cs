    static Type GetTypeOfSummation(Type t1, Type t2)
    {
        var p1 = Expression.Parameter(t1, "t1");
        var p2 = Expression.Parameter(t2, "t2");
    
        LambdaExpression x = DynamicExpression.ParseLambda(new[] { p1, p2 }, null, "t1 + t2");
        return x.Body.Type;
    }
