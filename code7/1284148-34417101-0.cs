    public static class LinqExtensions
    {
    	public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TKey, TValue> invoke)
    	{
    		foreach(var kvp in dictionary)
    			invoke(kvp.Key, kvp.Value);
    	}
    }
