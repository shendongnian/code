    public class CustomResponseResult<T> : IHttpActionResult {
        public CustomResponseResult(HttpStatusCode statusCode, T content, HttpRequestMessage request) {
            Content = content;
            Request = request;
            StatusCode = statusCode;
        }
        public T Content { get; private set; }
        public HttpRequestMessage Request { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            return Task.FromResult(Execute());
        }
        private HttpResponseMessage Execute() {
            var response = Request.CreateResponse(StatusCode, Content);
            response.RequestMessage = Request;
            response.ReasonPhrase = StatusCode.ToString();
            return response;
        }
    }
