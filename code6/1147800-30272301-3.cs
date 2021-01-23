    // Caching of the reflection
    private static readonly MethodInfo orderByMethod = GetOrderByMethod("OrderBy");
    private static readonly MethodInfo orderByDescendingMethod = GetOrderByMethod("OrderByDescending");
    private static IOrderedQueryable<TSource> ExpressionSort<TSource>(Order order, IQueryable<TSource> source, PropertyInfo property)
    {
        // Compose the expression tree that represents the parameter to 
        // the predicate.
        // The expression you would use is source => source.Property,
        // The parameter of the lambda, source
        ParameterExpression sourceExpression = Expression.Parameter(typeof(TSource), "source");
        // Accessing the expression
        MemberExpression propertyExpression = Expression.Property(sourceExpression, property);
        // The full lambda expression. We don't need the 
        // Expression.Lambda<>, but still the keySelector will be an
        // Expression<Func<,>>, because Expression.Lambda does it 
        // authomatically. LambdaExpression is simply a superclass of 
        // all the Expression<Delegate>
        LambdaExpression keySelector = Expression.Lambda(propertyExpression, sourceExpression);
        // The OrderBy method we will be using, that we have cached
        // in some static fields
        MethodInfo method = order == Order.ASC ? orderByMethod : orderByDescendingMethod;
        // Adapted from Queryable.OrderBy (retrieved from the reference
        // source code), simply changed the way the OrderBy method is
        // retrieved to "method"
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
        // Here I'm taking the long and more correct way to find OrderBy/
        // OrderByDescending: looking for a public static method with the
        // right name, with two generic arguments and that has the 
        // parameters related to those two generic arguments in a certain
        // way (they must be IQueryable<arg0> and Expression<Func<arg0,
        // arg1>>
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
