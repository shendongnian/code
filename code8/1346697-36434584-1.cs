    static class ObjectHelper
	{
		public static bool PertainsTo<T>(this T obj, IEnumerable<T> enumerable)
		{
			return (enumerable is List<T> ? (List<T>) enumerable : enumerable.ToList()).Contains(obj);
		}
	}
