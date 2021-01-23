    public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> source, string collectionName, string fieldName, string comparisonOperator, string searchVal) where TEntity : class
    {
    	var entity = Expression.Parameter(source.ElementType, "e");
    	var collection = Expression.PropertyOrField(entity, collectionName);
    	var elementType = collection.Type.GetInterfaces()
    		.Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
    		.GetGenericArguments()[0];
    	var element = Expression.Parameter(elementType, "i");
    	var elementMember = Expression.PropertyOrField(element, fieldName);
    	var elementPredicate = Expression.Lambda(
    		GenerateComparison(elementMember, comparisonOperator, searchVal),
    		element);
    	var callAny = Expression.Call(
    		typeof(Enumerable), "Any", new[] { elementType },
    		collection, elementPredicate);
    	var predicate = Expression.Lambda(callAny, entity);
    	var callWhere = Expression.Call(
    		typeof(Queryable), "Where", new[] { entity.Type },
    		source.Expression, Expression.Quote(predicate));
    	return source.Provider.CreateQuery<TEntity>(callWhere);
    }
    
    private static Expression GenerateComparison(Expression left, string comparisonOperator, string searchVal)
    {
    	var right = Expression.Constant(searchVal);
    	switch (comparisonOperator)
    	{
    		case "==":
    		case "Equals":
    			return Expression.Equal(left, right);
    		case "!=":
    			return Expression.NotEqual(left, right);
    	}
    	return Expression.Call(left, comparisonOperator, Type.EmptyTypes, right);
    }
