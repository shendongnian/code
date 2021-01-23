    public static class NullableExtensions
    {
    	public static List<T> SingletonList<T>(this Nullable<T> item) where T : struct
    	{
    		return item.HasValue ? new List<T> { item.Value } : new List<T>();
    	}
    }
