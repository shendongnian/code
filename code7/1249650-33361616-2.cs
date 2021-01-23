    public static IQueryable<T> ExecuteWhereClause<T,U>(IQueryable<T> inputQuery, U typedValue, String paramName)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(T));
        var condition =
                Expression.Lambda<Func<T,bool>>(
                    Expression.Equal(
                        Expression.Property(parameter, paramName),
                        Expression.Constant(typedValue)
                    ),
                    parameter
                );
        return inputQuery.Where(condition);
    }
