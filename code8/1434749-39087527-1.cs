    void Sample()
    {
	    var dataprovider = new Subject<int>();
	    var subscription = dataprovider
	    .Buffer(50)
	    .Subscribe(listOfNumbers => 
	    	{
	    		var batchSize = listOfNumbers.Count;
                        // do something with batch of items
	    	});
	
	    for(int i = 0; i <= 5; ++i)
	    {
	    	dataprovider.OnNext(i);
	    }
		
	    subscription.Dispose();
    }
