    public class KeyCountMap<T> 
    {
    	
    	private readonly IDictionary<T,MutableInt> _map;
    	
    	public KeyCountMap(){
    		
    		_map = new Dictionary<T,MutableInt>();
    	}
    }
    public class KeyCountMap<T> where T: IDictionary<T, MutableInt>, new()
        {
            private readonly T _map;
            public KeyCountMap()
            {
                _map = new T();
            }
        }
