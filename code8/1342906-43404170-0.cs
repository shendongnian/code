    public class JsonTextActionResult : IHttpActionResult
    {
        public HttpRequestMessage Request { get; }
        public string JsonText { get; }
        public JsonTextActionResult(HttpRequestMessage request, string jsonText)
        {
            Request = request;
            JsonText = jsonText;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        public HttpResponseMessage Execute()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonText, Encoding.UTF8, "application/json");
            return response;
        }
    }
