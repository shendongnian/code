    public class MyReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue> where TValue : struct
    {
        // other methods to implement here...
    	public MyReadOnlyDictionary(IReadOnlyDictionary<TKey, TValue?> kvps)
    	{
    		_kvps = kvps;
    	}
    	
    	private IReadOnlyDictionary<TKey, TValue?> _kvps;
    	
    	new public TValue this[TKey key]
    	{
    		get
    		{
    			TValue? val = _kvps[key];
    			if (val.HasValue)
    				return val.Value;
    			throw new KeyNotFoundException();
    		}
    	}
    }
