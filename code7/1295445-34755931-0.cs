    IOrderedEnumerable<TEntityType> SortMeDynamically<TEntityType>(IEnumerable<TEntityType> query, string propertyname)
    {
    	var param = Expression.Parameter(typeof(TEntityType), "s");
    	var prop = Expression.PropertyOrField(param, propertyname);
    	var sortLambda = Expression.Lambda(prop, param);
    	
    	Expression<Func<IOrderedEnumerable<TEntityType>>> sortMethod = (() => query.OrderBy<TEntityType, object>(k => null));
    	
    	var methodCallExpression = (sortMethod.Body as MethodCallExpression);
        if (methodCallExpression == null)
            throw new Exception("Oops");
    
        var method = methodCallExpression.Method.GetGenericMethodDefinition();
        var genericSortMethod = method.MakeGenericMethod(typeof(TEntityType), prop.Type);
        var orderedQuery = (IOrderedEnumerable<TEntityType>)genericSortMethod.Invoke(query, new object[] { query, sortLambda.Compile() });
    	
    	return orderedQuery;
    }
