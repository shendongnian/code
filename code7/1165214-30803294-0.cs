    protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, 
                CancellationToken cancellationToken)
    {
        // 4MB, perhaps you want to loosen this up a bit as other request
        // characteristics will effect the size.
        const int maxRequestSize = 4194304;
        IEnumerable<string> contentLengthHeader;
        request.Headers.TryGetValues("Content-Length", out contentLengthHeader);
        var contentLength = contentLengthHeader.FirstOrDefault();
        if (contentLength == null)
        {
            //No content-length sent, decide what to do.
        }
        long actualContentlength;
        if (!long.TryParse(contentLength, out actualContentlength))
        {
            // Couldn't parse, decide what to do.
        }
        if (actualContentlength > maxRequestSize)
        {
            // If reached, the content-length of the request was too big. 
            // Return an error response:
            return Task.FromResult(request.CreateErrorResponse(HttpStatusCode.Forbidden,
                string.Format("Request size exceeded {0} bytes", maxRequestSize)));
        }
        return base.SendAsync(request, cancellationToken);
    }
