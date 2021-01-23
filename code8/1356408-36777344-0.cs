    public class WtfDelegatingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (request.RequestUri.LocalPath.StartsWith("/api/", StringComparison.OrdinalIgnoreCase))
            {
                response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("I'm an API response")
                };
            }
            return response;
        }
    }
