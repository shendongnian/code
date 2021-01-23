    public static class CollectionExtension
    {
    	public static bool CheckContainsIfHasValue<T>(this IEnumerable<T> source, T value)
    	{
    		return source == null || source.Contains(value);
    	}
    }
