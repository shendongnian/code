    void Main()
    {
    	// If the payload is small, laziness toolkit is not neglectible
    	RunBenchmarks(i => i % 2 == 0, "Smaller payload");
    	
    	// Even this small string manupulation neglects overhead of laziness toolkit
    	RunBenchmarks(i => i.ToString().Contains("5"), "Larger payload");
    }
    
    void RunBenchmarks(Func<int, bool> payload, string what)
    {
    	Console.WriteLine(what);
    	var items = Enumerable.Range(0, 10000000).ToList();
    
    	Func<Func<int, bool>> createPredicateWithBoolean = () =>
    	{
    		bool computed = false;
    		return i => (computed || (computed = Compute())) && payload(i);
    	};
    
    	items.Count(createPredicateWithBoolean());
    	var sw = Stopwatch.StartNew();
    	Console.WriteLine(items.Count(createPredicateWithBoolean()));
    	sw.Stop();
    	Console.WriteLine("Elapsed using boolean: {0}", sw.ElapsedMilliseconds);
    
    	Func<Func<int, bool>> createPredicate = () =>
    	{
    		Func<int, bool> current = i =>
    		{
    			var computed2 = Compute();
    			current = j => computed2;
    			return computed2;
    		};
    		return i => current(i) && payload(i);
    	};
    
    	items.Count(createPredicate());
    	sw = Stopwatch.StartNew();
    	Console.WriteLine(items.Count(createPredicate()));
    	sw.Stop();
    	Console.WriteLine("Elapsed using smart predicate: {0}", sw.ElapsedMilliseconds);
    	Console.WriteLine();
    }
    
    bool Compute()
    {
    	return true; // not important for the exploration
    }
