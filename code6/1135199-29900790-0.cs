    void Main()
    {
    	var listOfObjects = Enumerable.Range(0, 100000).Select(x => new TestClass() { SomeProperty = x.ToString() }).ToArray();
        var iterations = DateTime.UtcNow.Day * 50;
        Console.WriteLine("Doing {0} iterations", iterations);
    	
        var sw = Stopwatch.StartNew();
    	for(int i = 0; i < iterations; i++)
    	{
    		var filteredList = listOfObjects.Where(x => x.SomeProperty.Contains('0') && x.SomeProperty.Contains('1')).ToArray();
    	}
    	sw.Stop();
    	
    	Console.WriteLine(sw.ElapsedMilliseconds);
    	
    	sw.Reset();
    	sw.Start();
    	for(int i = 0; i < iterations; i++)
    	{
    		var filteredList = listOfObjects.Where(x => x.SomeProperty.Contains('0')).Where(x => x.SomeProperty.Contains('1')).ToArray();
    	}
    	sw.Stop();
    	Console.WriteLine(sw.ElapsedMilliseconds);
    }
    
    public class TestClass
    {
    	public string SomeProperty { get; set; }
    	public string SomeOtherProperty { get; set; }
    }
