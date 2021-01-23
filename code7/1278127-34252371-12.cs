    public class GzipDecompressionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var isCompressedPayload = request.Content.Headers.ContentEncoding.Any(x => string.Equals(x, "gzip", StringComparison.InvariantCultureIgnoreCase));
            if (!isCompressedPayload)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            request.Content = new DecompressedHttpContent(request.Content);
            return await base.SendAsync(request, cancellationToken);
        }
    }
