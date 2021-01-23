	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> GetOrderedPermutations<T>(
												  this IEnumerable<T> collection)
		{
			var builder = new List<T>();
			foreach (var element in collection)
			{
				builder.Add(element);
				var local = new List<T>(builder);
				yield return local;
			}
		}
	}
