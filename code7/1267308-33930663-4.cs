    void Update()
    {    
    	bool again;
    
    	do
    	{
    		again = false;
    		// you probably want to optimise this so that we don't check the same items
    		// at the start again after removing an item
    		foreach (var delayedJob in _jobs)
    		{
    			if (!delayedJob.Update())
    			{
    				_jobs.Remove(delayedJob);
    				again = true; // start over
    				break;
    			}
    		}
    	}
    	while (again);    
    }
