	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> GetOrderedSubEnumerables<T>(
												  this IEnumerable<T> collection)
		{
			var builder = new List<T>();
			foreach (var element in collection)
			{
				builder.Add(element);
				yield return builder;
			}
		}
	}
	
