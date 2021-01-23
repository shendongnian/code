    void Main()
    {
    	IEnumerable<int> items = Test2();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        var newitems = new StringBuilder();
        foreach (var item in items)
        {
            newitems.Append(item);
        }
    }
    
    IEnumerable<int> Test2()
    {
    	Console.WriteLine("Test2 called");
    	return GetEnum();
    }
    
    IEnumerable<int> GetEnum()
    {
    	for(var i = 0; i < 5; i ++)
    	{
    		Console.WriteLine("Doing work...");
    		Thread.Sleep(50); //Download some information from a website, or from a database
    		yield return i;
    	}
    }
