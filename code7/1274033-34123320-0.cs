    public static partial class Utils
    {
    	public static Expression<Func<TItem, bool>> PropertyEquals<TItem, TValue>(string propertyPath, TValue value)
    	{
    		var source = Expression.Parameter(typeof(TItem), "source");
    		var propertyNames = propertyPath.Split('.');
    		var member = Expression.Property(source, propertyNames[0]);
    		for (int i = 1; i < propertyNames.Length; i++)
    			member = Expression.Property(member, propertyNames[i]);
    		Expression left = member, right = Expression.Constant(value, typeof(TValue));
    		if (left.Type != right.Type)
    		{
    			var nullableType = Nullable.GetUnderlyingType(left.Type);
    			if (nullableType != null)
    				right = Expression.Convert(right, left.Type);
    			else
    				left = Expression.Convert(left, right.Type);
    		}
    		var body = Expression.Equal(left, right);
    		var expr = Expression.Lambda<Func<TItem, bool>>(body, source);
    		return expr;
    	}
    }
