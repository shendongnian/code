    CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();
    HttpClient client = HttpClientFactory.Create(customDelegatingHandler);
    public class CustomDelegatingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                byte[] content = await request.Content.ReadAsByteArrayAsync();
                // Do what you need with the content here
            }
            response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
