        Expression<Func<Kitten, object>> property = c => c.KittenAge;
        var unaryExpression = property.Body as UnaryExpression;
    	var propertyExpression = unaryExpression.Operand as MemberExpression;
    
    	if (Nullable.GetUnderlyingType(propertyExpression.Type) == null)
    	{
    	  // Error, must be nullable
    	}
