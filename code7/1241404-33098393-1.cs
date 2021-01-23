    public static T Nullify<T>(this T item, params Expression<Func<T, object>> [] properties)
    {
    	foreach(var property in properties)
    	{
    		var memberSelectorExpression = property.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var propertyInfo = memberSelectorExpression.Member as PropertyInfo;
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(item, null, null);
                }
            }
    	}
    	
        return item;
    }
