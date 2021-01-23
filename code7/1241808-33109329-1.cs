    void Main()
    {
    	var collection = new List<string> { "One", "Two" };
    
    	var dict = new Dictionary<Func<string, bool>, Action<string>>
    	{
    		{ ConditionOne, ActionOne },
    		{ ConditionTwo, ActionTwo },
    	};
    	
    	Match(collection, dict);
    }
    
    public void Match<T>(IEnumerable<T> collection, 
        Dictionary<Func<T, bool>, Action<T>> matchMap)
    {
    	var wasMatched = false;
    	foreach (var item in collection)
    	{
    		if (wasMatched) break;
    	
    		foreach (var pair in matchMap)
    		{
    			if (wasMatched) break;
    			
    			if (pair.Key(item))
    			{
    				pair.Value(item);
    				wasMatched = true;
    			}	
    		}
    	}
    }
    
    public bool ConditionOne<T>(T item)
    {
    	return false;
    }
    
    public void ActionOne<T>(T item)
    {
    	Console.WriteLine(item);
    }
    
    public bool ConditionTwo<T>(T item)
    {
    	return true;
    }
    
    public void ActionTwo<T>(T item)
    {
    	Console.WriteLine(item);
    }
