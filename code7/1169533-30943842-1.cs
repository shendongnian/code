	public static class IEnumerableExtensions
	{
		public static IEnumerable<IList<T>> MakeSets<T>(this IEnumerable<T> items, Func<T, T, bool> areInSameGroup)
		{
			var result = new List<T>();
			foreach (var item in items)
			{
				if (!result.Any() || areInSameGroup(result[result.Count - 1], item))
				{
					result.Add(item);
					continue;
				}
				yield return result;
				result = new List<T> { item };
			}
			if (result.Any())
			{
				yield return result;
			}
		}
	}
