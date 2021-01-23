    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereAnyEquals<T>(this IQueryable<T> source, string collectionName, object value)
    	{
    		var e = Expression.Parameter(typeof(T), "e");
    		var collection = Expression.PropertyOrField(e, collectionName);
    		var itemType = (collection.Type.IsIEnumerableT() ? collection.Type :
    			collection.Type.GetInterfaces().Single(IsIEnumerableT))
    			.GetGenericArguments()[0];
    		var c = Expression.Parameter(itemType, "c");
    		var itemPredicate = Expression.Lambda(
    			Expression.Equal(c, Expression.Constant(value)),
    			c);
    		var callAny = Expression.Call(
    			typeof(Enumerable), "Any", new Type[] { itemType },
    			collection, itemPredicate);
    		var predicate = Expression.Lambda<Func<T, bool>>(callAny, e);
    		return source.Where(predicate);
    	}
    
    	private static bool IsIEnumerableT(this Type type)
    	{
    		return type.IsInterface && type.IsConstructedGenericType &&
    			type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
    	}
    }
