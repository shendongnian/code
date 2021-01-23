    public static class DictionaryExtensions
    {
    	public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey,TValue> self, TKey key)
    	{
    		TValue value;
    		self.TryGetValue(key,out value);
    		return value;
    	}
    }
    public string Foo
    {
        get
        {    
            return PropertyBag.GetValueOrDefault("Foo");
        }
        set
        {
            PropertyBag["Foo"] = value;
        }
    }
