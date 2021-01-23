	public class IDCollection
	{
		private IDictionary<string, ID> List = new Dictionary<string, ID>() { { "x", new ID() }, } ;
	
		public IEnumerable<KeyValuePair<string, ID>> Where(Func<KeyValuePair<string, ID>, bool> selector)
		{
			return List.Where(selector);
		}
	
		public IEnumerable<TResult> Select<TResult>(Func<KeyValuePair<string, ID>, TResult> selector)
		{
			return List.Select(selector);
		}
	}
