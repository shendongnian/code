    public static class MyExtensions
	{
		public static IEnumerable <TData> InBetween <TData> (this IEnumerable <TData> Target, TData StartItem, TData EndItem)
		{
			var Comparer = EqualityComparer <TData>.Default;
			var FetchData = false;
			var StopIt = false;
			foreach (var Item in Target) {
				if (StopIt)
					break;
				if (Comparer.Equals (Item, StartItem))
					FetchData = true;
				if (Comparer.Equals (Item, EndItem))
					StopIt = true;
				if (FetchData)
					yield return Item;
			}
            yield break;
		}
	}
