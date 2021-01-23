    class AuthenticationFailureResult : IHttpActionResult
    {
    	private HttpRequestMessage _request;
    
    	public AuthenticationFailureResult(HttpRequestMessage request)
    	{
    		_request = request;
    	}
    
    	public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    	{
    		HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
    		response.RequestMessage = _request;
    		response.Content = new StringContent("ACCESS DENIED MESSAGE");
    
    		return Task.FromResult(response);
    	}
    }
