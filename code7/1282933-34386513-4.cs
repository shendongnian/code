    public async Task<ActionResult> Accept(string id)
    {
    	var request = await UpdateRequest(id, RequestOutcome.Accept);
    
    	if (request!= null)
    	{
    		var c = request.DateConcluded;
    	}
    }
