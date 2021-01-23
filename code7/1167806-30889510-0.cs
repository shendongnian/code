    public static Func<Agent, object> GetOrderBySelector(string propertyName)
    {
    	var parameter = Expression.Parameter(typeof(Agent), "a");
    	var property = Expression.Property(parameter, propertyName);
    	// a => a.PropertyName is a unary expression
    	var unaryExpression = Expression.Convert(property, typeof(object));
    	// Create the lambda for the unary expression with the given property 
        // information and compile to return the actual delegate.
    	return Expression.Lambda<Func<Agent, object>>(unaryExpression, parameter).Compile();
    }
