    void Main()
    {
    	Dictionary<string, int> primaryDict = new Dictionary<string, int>
    	{
    		{"key1", 33}, 
    		{"key2", 24}, 
    		{"key3", 21}, 
    		{"key4", 17}, 
    		{"key5", 12}
    	};
	
	    Dictionary<string, int> secondaryDict = new Dictionary<string, int>
	    {
		    {"key1", 22}, 
		    {"key3", 20}, 
		    {"key4", 19}, 
		    {"key7", 17}, 
		    {"key8", 10}
	    };
	
	    var resultDict =  primaryDict.Where(x => !secondaryDict.ContainsKey(x.Key))
                         .ToDictionary(x => x.Key, x => x.Value);
						 
	    Console.WriteLine(resultDict);
    }
