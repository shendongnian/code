    if (selector.Type != typeof(string))
    {
    	if (selector.Type == typeof(DateTime))
    		selector = selector.ToDateString();
    	else if (selector.Type == typeof(DateTime?))
    		selector = Expression.Condition(
    			Expression.NotEqual(selector, Expression.Constant(null, typeof(DateTime?))),
    			Expression.Convert(selector, typeof(DateTime)).ToDateString(),
    			Expression.Constant(""));
    	else
    		selector = Expression.Call(selector, Object_ToString);
    }
