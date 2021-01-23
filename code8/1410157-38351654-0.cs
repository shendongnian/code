    static Expression<Func<TSource, bool>> MakeCountPredicate<TSource>(string collectionName, string itemName, ExpressionType itemComparison, string itemValue, ExpressionType countComparison, int countValue)
    {
    	var source = Expression.Parameter(typeof(TSource), "s");
    	var collection = Expression.Property(source, collectionName);
    	var itemType = collection.Type.GetInterfaces()
    		.Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
    		.GetGenericArguments()[0];
    	var item = Expression.Parameter(itemType, "e");
    	var itemProperty = Expression.Property(item, itemName);
    	var itemPredicate = Expression.Lambda(
    		Expression.MakeBinary(itemComparison, itemProperty, Expression.Constant(
    			string.IsNullOrEmpty(itemValue) || itemValue.Equals("null", StringComparison.OrdinalIgnoreCase) ? null :
    			Convert.ChangeType(itemValue, itemProperty.Type))),
    		item);
    	var itemCount = Expression.Call(
    		typeof(Enumerable), "Count", new[] { itemType },
    		collection, itemPredicate);
    	var predicate = Expression.Lambda<Func<TSource, bool>>(
    		Expression.MakeBinary(countComparison, itemCount, Expression.Constant(countValue)),
    		source);
    	return predicate;
    }
