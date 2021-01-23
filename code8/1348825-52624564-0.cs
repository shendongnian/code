    public class FakeHttpMessageHandler : HttpMessageHandler
    	{
    		public Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> HttpRequestHandler =>
    			(r, c) => Task.FromResult(new HttpResponseMessage
    				{
    					ReasonPhrase = r.RequestUri.AbsoluteUri,
    					StatusCode = HttpStatusCode.OK
    				});
    
    
    		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    		{
    			return HttpRequestHandler(request, cancellationToken);
    		}
    	}
