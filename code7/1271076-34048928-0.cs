    public async Task<HttpResponseMessage> ServiceAAction()
    {
    	try
    	{
    		var client = new HttpClient();
    		client.GetAsync("http://URLtoWebApi/ServiceB").ContinueWith(HandleResponse);
    
    		// any code here will execute immediately because the above line is not awaited
    
    		// return response to the client indicating service A is 'done'
    		return Request.CreateResponse(HttpStatusCode.OK);
    
    	}
    	catch
    	{
    		throw new HttpResponseException(HttpStatusCode.InternalServerError);
    	}
    }
    
    private async void HandleResponse(Task<HttpResponseMessage> response)
    {
    	try
    	{
    		// await the response from service B
    		var result = await response;
    
    		// do work
    
    		// dont attempt to return anything, service A has already returned a response to the client
    	}
    	catch (Exception e)
    	{
    		throw;
    	}
    }
