    public class derivedData : sharedData
    {
    	public string test;
    	
    	public derivedData(string meta, int value) : base(meta, value)
    	{
            // you can't do assignment in the class scope, unless it can be done statically, it has to be inside a method block
    		test = string.Format("Shared meta = {0}, Shared Value = {1}", GlobMeta, GlobValue);
    	}
        
        // or, if you prefer to have a parameterless ctor
    	public derivedData() : base("a default value for meta", default(int))
    	{
    		test = string.Format("Shared meta = {0}, Shared Value = {1}", GlobMeta, GlobValue);
    	}
    }
