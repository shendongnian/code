    public class AddCustomHeadersResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
             var response = await base.SendAsync(request, cancellationToken);
             response.Headers.Add("Content-Security-Policy", "yourSecurityValue");
             response.Headers.Add("X-Frame-Options", "yourFrameOptions");
             return response;
        }
    }
