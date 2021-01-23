    var inner = Observable.Create<string>((o) =>
    {
    	o.OnNext("First item of new inner");
    	return Disposable.Create(() => "Inner Disposed".Dump());
    });
    
    var outer = Observable.Timer(TimeSpan.MinValue, TimeSpan.FromSeconds(10))
    		.Select(_ => inner)
    		.Switch()
    		.Subscribe(output => output.Dump());
    		
    
    Console.ReadLine();
    
    outer.Dispose();
