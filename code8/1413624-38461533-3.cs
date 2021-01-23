    public class NormalizeHandler : DelegatingHandler
    {
        public NormalizeHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var source = await request.Content.ReadAsStringAsync();
            source = source.Replace("json=", "");
            source = HttpUtility.UrlDecode(source);
            request.Content = new StringContent(source, Encoding.UTF8, "application/json");
            return await base.SendAsync(request, cancellationToken);
        }
    }
