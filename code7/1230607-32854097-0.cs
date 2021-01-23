    public class AuthenticationFailureResult : IHttpActionResult
    {
        public AuthenticationFailureResult(object jsonContent, HttpRequestMessage request)
        {
            JsonContent = jsonContent;
            Request = request;
        }
        public HttpRequestMessage Request { get; private set; }
        public Object JsonContent { get; private set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            response.Content = new ObjectContent(JsonContent.GetType(), JsonContent, new JsonMediaTypeFormatter());
            return response;
        }
    }
