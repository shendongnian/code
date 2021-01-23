	public class IDCollection : IEnumerable<KeyValuePair<string, ID>>
	{
		private IDictionary<string, ID> List = new Dictionary<string, ID>();
	
		IEnumerator<KeyValuePair<string, ID>> IEnumerable<KeyValuePair<string, ID>>.GetEnumerator()
		{
			return List.GetEnumerator();
		}
	
		IEnumerator IEnumerable.GetEnumerator()
		{
			return List.GetEnumerator();
		}
	}
