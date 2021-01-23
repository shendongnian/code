    public static class Extensions
    {
    	public static bool IsDefault<T>(this T source)
    	{
    		return EqualityComparer<T>.Default.Equals(source, default(T));
    	}
    }
