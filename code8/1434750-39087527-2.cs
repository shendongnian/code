    void Sample()
    {
	    var dataprovider = new Subject<int>();
	    var subscription = dataprovider
	        .Buffer(TimeSpan.FromMinutes(3))
	        .Subscribe(listOfNumbers => 
	    	{
                // do something with batch of items
	    		var batchSize = listOfNumbers.Count;
	    	});
	
	    for(int i = 0; i <= 5; ++i)
	    {
	    	dataprovider.OnNext(i);
	    }
		
	    subscription.Dispose();
    }
