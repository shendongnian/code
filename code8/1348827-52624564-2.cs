    public class FakeHttpMessageHandler : HttpMessageHandler
    	{
    		public Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> HttpRequestHandler { get; set; } =
			(r, c) => 
				new HttpResponseMessage
				{
					ReasonPhrase = r.RequestUri.AbsoluteUri,
					StatusCode = HttpStatusCode.OK
				};
    
    
    		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    		{
    			return Task.FromResult(HttpRequestHandler(request, cancellationToken));
    		}
    	}
