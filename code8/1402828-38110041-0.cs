    CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();
    HttpClient client = HttpClientFactory.Create(customDelegatingHandler);
    public class CustomDelegatingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                byte[] content = await request.Content.ReadAsByteArrayAsync();
            }
            response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
