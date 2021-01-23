	void Main()
	{
		IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
		numbers.Each(Console.WriteLine);
	}
	
	public static class Extensions 
	{
		public static IEnumerable<T> Each<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var element in enumerable)
			{
				action.Invoke(element);
			}
			
			return enumerable;
		}
	}
