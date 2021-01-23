    public Expression<Func<TEntity, bool>> GeneratorEqualityTest<TProperty>(Expression<Func<TEntity, TProperty>> accessor, TProperty expectedValue)
    {
    	var body = Expression.Equal(accessor.Body, Expression.Constant(expectedValue));
    	var predicate = Expression.Lambda<Func<TEntity, bool>>(body, accessor.Parameters);
    	return predicate; 
    }
