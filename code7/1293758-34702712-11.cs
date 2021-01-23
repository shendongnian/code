	public class IDCollection
	{
		private IDictionary<string, ID> List = new Dictionary<string, ID>() { { "x", new ID() }, } ;
	
		public IEnumerable<KeyValuePair<string, ID>> AsEnumerable()
		{
			return List.Select(x => x);
		}
	}
