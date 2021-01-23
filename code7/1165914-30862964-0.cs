    Observable.Create<string>(observer =>
    {
	    var queue = new Queue<long>(3);
	
        return Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(value =>
    	{
    		if (queue.Count == 3)
    		{
    			queue.Dequeue();
    		}
    		
    		queue.Enqueue(value);
    		
    		if (queue.Count == 3)
    		{
    			var values = queue.ToArray();
    			if (values.All(v => v > 3))
    			{
    				observer.OnNext("All above 3. " + values[0] + " " + values[1] + " " + values[2]);
    			}
    		}
    	});
    })
