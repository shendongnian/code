    static Delegate CreateDelegate(Type[] parameterTypes, Type returnType)
    {
       var parameters = parameterTypes.Select(Expression.Parameter)
                                      .ToArray();    
        var body = Expression.Default(returnType);    
        var lambda = Expression.Lambda(body, false, parameters);    
        return lambda.Compile();
    }
