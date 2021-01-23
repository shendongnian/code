	public class KeyCountMap<T>
	    where T : new()
	{
		private Dictionary<T, MutableInt> map = new Dictionary<T, MutableInt>();
		// ... rest of properties...  
	
		public KeyCountMap()
		{ }
	
		public KeyCountMap(T obj)
		{
			obj = new T();
			map = (Dictionary<T, MutableInt>)(object)obj;
		}
	}
