    public class RichBadRequestResponse : BadRequestResult
    {
        public IEnumerable<string> errors { get; set; }
        public string Message { get; set; }
        public ModelStateDictionary modelState { get; set; }
        private HttpRequestMessage _request;
        public RichBadRequestResponse(HttpRequestMessage request)
            : base(request)
        {
            _request = request;
        }
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var dataObj = new
            {
                errors = errors.ToArray(),
                message = Message ?? string.Join(", ", errors)
            };
            
            if (_request.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue("applicaiton/xml")))
            {
                Console.WriteLine("Foo");
            }
            ///// Changed Line
            var resp = _request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            return Task.FromResult(resp);
        }
    }
