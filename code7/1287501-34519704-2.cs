    public class SomethingFailedResult : IHttpActionResult
    {
        private HttpControllerContext _Context { get; set; }
        private string _Message { get; set; }
        public SomethingFailedResult(HttpControllerContext context, string message)
        {
            _Context = context;
            _Message = message;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_Context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                _Message, "someMediaType"));
        }
    }
