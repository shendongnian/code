    public class MyResponse : IHttpActionResult
    {
        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }
    
    
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(ExecuteResult());
        }
    
        public HttpResponseMessage ExecuteResult()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted);
    
            response.Content = new StringContent(Message);
            response.RequestMessage = Request;
            return response;
        }
    }
