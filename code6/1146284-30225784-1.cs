    void Main()
    {
    	IEnumerable<string> ienumerable = GetStrings();
    	var test1 = new Stopwatch();
    	test1.Start();
    	var count1 = ienumerable.Count();
    	test1.Stop();
    	test1.ElapsedTicks.Dump();
    	
    	var test2 = new Stopwatch();
    	test2.Start();
    	var count2 = ienumerable.ToList().Count;
    	test2.Stop();
    	test2.ElapsedTicks.Dump();
        var test3 = new Stopwatch();
	    test3.Start();
	    var count3 = ienumerable.Count();
	    test3.Stop();
	    test3.ElapsedTicks.Dump();
    }
    
    public IEnumerable<string> GetStrings()
    {
        var testString = "test";
    	var strings = new List<string>();
    	for (int i = 0; i < 500000; i++)
    	{
    		strings.Add(testString);
    	}
    	
    	return strings;
    }
