	public static IEnumerable<T> GetNonNullValues<T>(this IEnumerable<Nullable<T>> items) where T: struct
	{
		return items.Where(a=>a.HasValue).Select(a=>a.Value);
	}
	
 
