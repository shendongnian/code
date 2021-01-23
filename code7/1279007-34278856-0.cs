    static Expression<T> ToExpr<T>(T func)
    {
        var type = typeof(T);
        var method = type.GetMethod("Invoke"); // Delegate.Invoke() has parameters types matching delegate parameters types
        var pars = method.GetParameters()
            .Select(pi => Expression.Parameter(pi.ParameterType))
            .ToArray();
        return Expression.Lambda<T>(
            Expression.Call(Expression.Constant(func), method, pars),
            pars
        );
    }
