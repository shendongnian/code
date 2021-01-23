    public class RawJsonActionResult : IHttpActionResult
    {
        private readonly string _jsonString;
        public RawJsonActionResult(string jsonString)
        {
            _jsonString = jsonString;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var content = new StringContent(_jsonString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
            return Task.FromResult(response);
        }
    }
