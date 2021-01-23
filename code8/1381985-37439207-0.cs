    public class KeyCountMap<T> 
    {
    	
    	private readonly _map IDictionary<T,MutableInt> _map;
    	
    	public KeyCountMap(){
    		
    		_map = new Dictionary<T,MutableInt>();
    	}
    }
