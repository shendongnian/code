	public static class AsyncExtensions
	{
		public static async Task<bool> AnyAsync<T>(
			this IEnumerable<T> source, Func<T, Task<bool>> func)
		{
			foreach (var element in source)
			{
				if (await func(element))
					return true;
			}
			return false;
		}
	}
