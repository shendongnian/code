	public static class EnumerableExtensions
	{
		public static HashSet<T> ToHashSet(this IEnumerable<T> enumerable)
		{
			return new HashSet<T>(enumerable);
		}
	}
