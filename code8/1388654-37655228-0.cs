    public Expression Distinct(IQueryable queryable, string propertyName)
    {
    	var propInfo = queryable.ElementType.GetProperty(propertyName);
    	var collectionType = queryable.ElementType;
    
    	var groupParameterExpression = Expression.Parameter(collectionType, "g");
    	var propertyAccess = Expression.MakeMemberAccess(groupParameterExpression, propInfo);
    	var groupLambda = Expression.Lambda(propertyAccess, groupParameterExpression);
    	var groupExpression = Expression.Call(typeof(Queryable), "GroupBy", new Type[] { collectionType, propInfo.PropertyType }, queryable.Expression, Expression.Quote(groupLambda));
    
    	var selectParameterExpression = Expression.Parameter(groupExpression.Type.GetGenericArguments().Single(), "s");
    	var selectFirstOrDefaultMethodExpression = Expression.Call(typeof(Enumerable), "FirstOrDefault", new Type[] { collectionType }, selectParameterExpression);
    	var selectLambda = Expression.Lambda(selectFirstOrDefaultMethodExpression, selectParameterExpression);
    	return Expression.Call(typeof(Queryable), "Select", new Type[] { selectParameterExpression.Type, selectLambda.Body.Type }, groupExpression, Expression.Quote(selectLambda));
    }
