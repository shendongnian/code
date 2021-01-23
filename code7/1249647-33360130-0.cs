    public IQueryable<Object> ExecuteWhereClause(IQueryable<Object> inputQuery, Object typedValue, Type viewType, String paramName, Type paramType)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(Object));
        var condition =
             Expression.Lambda<Func<Object, bool>>(
                 Expression.Equal(
                     Expression.Property(Expression.Convert(parameter, viewType), paramName),
                     Expression.Constant(typedValue, paramType)
                 ),
                 parameter
             );
        return inputQuery.Where(condition);
    }
