        var obs1 = Observable.Interval(TimeSpan.FromSeconds(1)).Timestamp();
    	var obs2 = Observable.Interval(TimeSpan.FromSeconds(2)).Timestamp();
    	
    	var result = Observable.CombineLatest(obs1, obs2, (v1, v2) =>
    	{
    		if(v1.Timestamp > v2.Timestamp)
    		{
    			Console.WriteLine("v1 " + v1.Timestamp);
    			return v1;
    		}
    		else
    		{
    			Console.WriteLine("v2 " + v1.Timestamp);
    			return v2;
    		}		
    	});
    	
    	result.Subscribe(x => Console.WriteLine(x));
