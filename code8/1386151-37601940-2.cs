	public static object ExecuteLinqMethod<T>(IQueryable<T> q, string Field, string Method)
    {
        var propInfo = typeof(T).GetProperty(Field);
		LambdaExpression exp;
		var myAttr = propInfo.GetCustomAttributes(typeof(CalculatedByAttribute), true).OfType<CalculatedByAttribute>().FirstOrDefault();
		if (myAttr != null)
			exp = (LambdaExpression)typeof(T).GetField(myAttr.StaticMethodName, BindingFlags.Static | BindingFlags.Public).GetValue(null);
		else
		{
	        var param = Expression.Parameter(typeof(T), "p");
	    	Expression prop = Expression.Property(param, Field);
        	exp = Expression.Lambda(prop, param);
		}
			
		Type[] types = new Type[] { q.ElementType, exp.Body.Type };
		var mce = Expression.Call(typeof(Queryable),Method,types,q.Expression,exp);
		
		return q.Provider.Execute(mce);
    }
