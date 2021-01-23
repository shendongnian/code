    public void ParentFunction()
    {
    	foreach (var item in someArray)
    	{
    		if(!TryExecute(procedure1())
    			continue;
    		if(!TryExecute(procedure2())
    			continue;
    			
    		TryExecute(procedure3());	
    	}   
    }
    
    public bool TryExecute(Action action)
    {
    	try
    	{
    		action.Invoke();
    		return true;
    	}
    	catch(Exception exc)
    	{
          console.Writeline(exc.Message);
    	  return false;
    	}
    }
