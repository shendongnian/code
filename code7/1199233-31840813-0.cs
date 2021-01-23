    public class NiceInternalServerExceptionResponse : IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }
        public HttpRequestMessage request { get; set; }
    
        public NiceInternalServerExceptionResponse(string message, HttpStatusCode code)
        {
            Message = message;
            StatusCode = code; 
        }
    
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(StatusCode);
            response.RequestMessage = request;
            response.Content = new StringContent(Message);
            return Task.FromResult(response);
        }
    }
