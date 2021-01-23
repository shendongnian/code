    public static class TestExtension
    {
    	public static String nameof<T, TT>(this T obj, Expression<Func<T, TT>> propertyAccessor)
    	{
    		if (propertyAccessor.Body.NodeType == ExpressionType.MemberAccess)
    		{
    			return ((dynamic)propertyAccessor.Body).Member.Name;
    		}
    		return null;
    	}
    }
