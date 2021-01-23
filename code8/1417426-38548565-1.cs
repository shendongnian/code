    void Main()
    {
    	var allowed = ObjectType.A | ObjectType.C;
    
    	var values = new int [] { 1, 2, 4, 8 };
    
    	foreach (var i in values)
    	{
    		var test = (ObjectType)i;
    
    		if ((test & allowed) == test)
    		{
    			Console.WriteLine("Found a match: {0}", test);
    		}
    		else
    		{
    			Console.WriteLine("No match: {0}", test);
    		}
    	}
    }
