    // Caching of the reflection
    private static readonly MethodInfo orderByMethod = GetOrderByMethod("OrderBy");
    private static readonly MethodInfo orderByDescendingMethod = GetOrderByMethod("OrderByDescending");
        
    private static IOrderedQueryable<TSource> ExpressionSort<TSource>(Order order, IQueryable<TSource> source, PropertyInfo property)
    {
        // Compose the expression tree that represents the parameter to the predicate.
        ParameterExpression sourceExpression = Expression.Parameter(typeof(TSource), "source");
        MemberExpression propertyExpression = Expression.Property(sourceExpression, property);
        LambdaExpression keySelector = Expression.Lambda(propertyExpression, sourceExpression);
        MethodInfo method = order == Order.ASC ? orderByMethod : orderByDescendingMethod;
        // Adapted from Queryable.OrderBy
        return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, method.MakeGenericMethod(new Type[]
	    {
		    typeof(TSource),
		    property.PropertyType
	    }), new Expression[]
	    {
		    source.Expression,
		    Expression.Quote(keySelector)
	    }));
    }
    private static MethodInfo GetOrderByMethod(string methodName)
    {
        MethodInfo orderByMethod = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                    where x.Name == methodName
                                    let generics = x.GetGenericArguments()
                                    where generics.Length == 2
                                    let parameters = x.GetParameters()
                                    where parameters.Length == 2 &&
                                        parameters[0].ParameterType == typeof(IQueryable<>).MakeGenericType(generics[0]) &&
                                        parameters[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(generics))
                                    select x).Single();
        return orderByMethod;
    }
