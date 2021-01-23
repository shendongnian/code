    public class FakeFastDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
    	protected IList<KeyValuePair<TKey, TValue>> _list 
    		= new List<KeyValuePair<TKey, TValue>>();
    	
    	public new void Add(TKey key, TValue value)
    	{
    		_list.Add(new KeyValuePair<TKey, TValue>(key, value));
    	}
    	
    	public new IList<TValue> Values()
    	{
    		// there may be faster ways to to it:
    		return _list.Select(x => x.Value).ToList();
    	}
    	
    }
	
	
