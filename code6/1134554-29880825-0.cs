    public class JSONClass : JSONNode, IEnumerable
	{
		public Dictionary<string, JSONNode>.KeyCollection keys
		{
			get {
				return m_Dict.Keys;
			}
		}
    }
