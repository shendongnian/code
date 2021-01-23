    private object _lock = new object();
    public void Load(int someID)
    {
    	if (IsLoaded) //No-locked check, early exit.
    		return;
    		
    	lock (_lock) //We think it's not loaded, lock to prevent issues and double check
    		if (IsLoaded)
    			return;
    		else
    			IsLoaded = true; //Immediately set IsLoaded = true
    	
    	try 
        {
    		//Do loading stuff
    	} catch (Exception ex) {
    		lock(_lock)
    			IsLoaded = false; //We failed to load, set back to false again
    			
    		throw;
    	}
    }
