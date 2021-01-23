    if (value.Type != typeof(string))
    {
    	if (value.Type == typeof(DateTime))
    		value = value.ToDateString();
    	else if (value.Type == typeof(DateTime?))
    		value = Expression.Condition(
    			Expression.NotEqual(value, Expression.Constant(null, typeof(DateTime?))),
    			Expression.Property(value, "Value").ToDateString(),
    			Expression.Constant(""));
    	else
    		value = Expression.Call(value, Object_ToString);
    }
