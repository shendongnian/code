    public static class TypeExtensions
    {
    	public static object GetDefault(this Type t)
    	{
    		Func<object> f = GetDefault<object>; // quick hack to get generic method
    		return f.Method.GetGenericMethodDefinition().MakeGenericMethod(t).Invoke(null, null);
    	}
    
    	private static T GetDefault<T>()
    	{
    		return default(T);
    	}
    }
