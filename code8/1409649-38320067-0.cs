    string x = "[[99,\"abc\",\"2dp\",{\"Group\": 0,\"Total\":[4, 1]}],[7,\"x\",\"date\"],[60,\"x\",\"1dp\",{\"Group\": 1}]]";
    List<List<object>> xobj = JsonConvert.DeserializeObject<List<List<object>>>(x);
    
    for(int i = 0; i < x.Count; i++)
    {
    	... 
    	// Do something with index 0 to 3
    	if(x[i].Count == 4)
    	{
    		// I have the optional entry with Group & Total properties
    		dynamic opt = x[i][3];
    		Console.WriteLine(opt.Group);
    		Console.WriteLine(opt.Total);
    	}
    }
