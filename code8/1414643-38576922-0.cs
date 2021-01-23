    public class ForwardedProtocolHeadersHandler : DelegatingHandler
    {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var forwardedProtocolHeader = request.Headers.FirstOrDefault(x =>
            string.Equals(x.Key, "X-Forwarded-Proto", StringComparison.InvariantCultureIgnoreCase));
        if (!string.IsNullOrEmpty(forwardedProtocolHeader.Key))
        {
            var isHttps = string.Equals(forwardedProtocolHeader.Value.Single(), Uri.UriSchemeHttps, StringComparison.InvariantCultureIgnoreCase);
            var urlBuilder = new UriBuilder(request.RequestUri)
            {
                Scheme = isHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp,
                Port = isHttps ? 443 : 80,
            };
            request.RequestUri = urlBuilder.Uri;
        }
        return base.SendAsync(request, cancellationToken);
    }
    }
