    public static class Extension
    {
    	public static List<T> EmptyIfNull<T>(this List<T> list)
    	{
    		return list ?? new List<T>();
    	}
    	public static T[] EmptyIfNull<T>(this T[] arr)
    	{
    		return arr ?? new T[0];
    	}
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable)
        {	
    		return enumerable ?? Enumerable.Empty<T>();
        }
    }
