    public static class Extensions
    {
    	public static bool IsDefault<T>(this T source)
    	{
    		return source == null || EqualityComparer<T>.Default.Equals(source, default(T));
    	}
    }
