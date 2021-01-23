    var item = Expression.Parameter(typeof(T), "item");
    Expression body = Expression.Equal(Expression.Property(item, "Id"), Expression.Constant(id));
    if (!string.IsNullOrEmpty(someStringColumn))
    {
    	var properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string)).ToList();
    	if (properties.Any())
    		body = Expression.AndAlso(body,
    			properties.Select(p => (Expression)Expression.Call(
    				Expression.Property(item, p), "Contains", Type.EmptyTypes, Expression.Constant(someStringColumn))
    			).Aggregate(Expression.OrElse));
    }		
    var whereExpression = Expression.Lambda<Func<T, bool>>(body, item);
