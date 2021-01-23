    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public HttpRequestMessage Request;
        public string LastRequestString = string.Empty;
        public string ResponseContent = string.Empty;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content != null) // needed this to prevent some NPEs in other tests, YMMV
            {
                LastRequestString = await request.Content.ReadAsStringAsync();
            }
            Request = request;
            return await Task.FromResult(new HttpResponseMessage
            {
                Content = new StringContent(ResponseContent)
            });
        }
    }
