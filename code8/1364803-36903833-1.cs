    public class MyClass
    {
    	private readonly Lazy<IReadOnlyDictionary<string, MyEnum>> _kvps;
    	public MyClass(IEnumerable<KeyValuePair<string, MyEnum? >> kvps)
    	{
    		_kvps = new Lazy<IReadOnlyDictionary<string, MyEnum>>(() =>
    		{
    			var filtered =
    				from kvp in kvps
    				where kvp.Value.HasValue
    				select kvp;
    			return new ReadOnlyDictionary<string, MyEnum>(filtered.ToDictionary(kvp => kvp.Key, kvp => (MyEnum)kvp.Value));
    		}
    
    		);
    	}
    
    	public IReadOnlyDictionary<string, MyEnum> Kvps
    	{
    		get
    		{
    			return _kvps.Value;
    		}
    	}
    }
