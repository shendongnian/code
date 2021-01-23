    static Expression CreateExpression(ParameterExpression param, string propertyName)
    {
        Expression body = param;
        foreach (var member in propertyName.Split('.'))
        {
            body = Expression.PropertyOrField(body, member);
        }
        return Expression.Lambda(body, param);
    }
