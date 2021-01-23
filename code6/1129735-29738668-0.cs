    If( typeof(T)==typeof(string))
    {
        ParameterExpression pe = System.Linq.Expressions.Expression.Parameter(typeof(T), "p");
        Expression<Func<T, TPropertyType>> expr = System.Linq.Expressions.Expression.Lambda<Func<T, TPropertyType>>(pe,pe);
    }
