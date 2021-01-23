    public IEnumerable<T> GetRecordList(DateTime date)
    {
        var parameterExpression = Expression.Parameter(typeof(T), "object");
        var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, "Date");
        var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(date, typeof(DateTime)));
        var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);
    
        var query = _genericRepository.FindBy(lambdaExpression);
        return query;
    }
