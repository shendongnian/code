    void Main()
    {
    	var t1 = new Thread(_ => {
    		var sw = Stopwatch.StartNew();
    		DoSomething();
    		Console.WriteLine("took {0}ms", sw.ElapsedMilliseconds);
    	});
    	var t2 = new Thread(_ => {
    		var sw = Stopwatch.StartNew();
    		DoSomethingElse();
    		Console.WriteLine("took {0}ms", sw.ElapsedMilliseconds);
    	});
    	t1.Start();
    	t2.Start();
    	t1.Join();
    	t2.Join();
    	Console.ReadKey();
    }
    
    void DoSomething()
    {
        //do something
    }
    
    void DoSomethingElse()
    {
        //do something
    }
