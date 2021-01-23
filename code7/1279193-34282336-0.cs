	public static class LINQExtension
	{
		public static double Median(this IEnumerable<double> source)
		{
			if (source.Count() == 0)
			{
				throw new InvalidOperationException("Cannot compute median for an empty set.");
			}
			var sortedList = from number in source
							 orderby number
							 select number;
			int itemIndex = (int)sortedList.Count() / 2;
			if (sortedList.Count() % 2 == 0)
			{
				// Even number of items.
				return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
			}
			else
			{
				// Odd number of items.
				return sortedList.ElementAt(itemIndex);
			}
		}
	}
