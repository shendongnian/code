	public class Grouping<TKey, TElement>
	{
		public TKey Key { get; set; }
		public IEnumerable<TElement> Elements { get; set; }
	}
