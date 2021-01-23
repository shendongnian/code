    ....
    var convObj = new
    {
        id = convertedId
    };
    var rightExp = Expression.Convert(Expression.Property(Expression.Constant(convObj), "id"), convertedId.GetType());
    
    var whereExpression = Expression.Lambda<Func<T, bool>>
        (
        Expression.Equal(
            Expression.Property(
                itemParameter,
                prop.Name
                ),
            rightExp
            ),
        new[] { itemParameter }
        );
    
    return Get<T>().Where(whereExpression);
