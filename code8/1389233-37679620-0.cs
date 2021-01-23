    [HttpPost]
    public  bool Update(QuotesTable model)
    {
    	try
    	{
    		var t = db.QuoteLines.SingleOrDefault(x => x.QuoteLineID == model.QuoteLineID);		
    		
    		if (!ModelState.IsValid)
    		{
    			//Throw some exception or any other validation logic
    			//only if model is not valid.
    		}
    		
    		if(t == null)
    		{
    			//Throw some exception or any other validation logic
    			//only if the QuoteLine doesn't exist
    		}		
    		
    		//I believe you meant something like this?
    		t.LostReasonId = model.LostReasonId;
    			
    		//More updates here in t...
    		
    		db.SaveChanges();
    	}
    	catch (Exception)
    	{
    		throw;
    	}
    	
    	return true;
    }
