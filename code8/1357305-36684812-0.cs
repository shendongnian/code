    void Main()
    {
    	var listOfThings = GetThings();
    	if (listOfThings.Any())
    	{
    		foreach (var item in listOfThings)
    		{
    			Console.WriteLine("A");
    		}
    	}
    }
    
    public IEnumerable<int> GetThings()
    {
    	Thread.Sleep(10000);
    	yield return 1;
    }
