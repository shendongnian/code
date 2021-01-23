    public class DecodeQueryStringMessageHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                if (request.Method == HttpMethod.Get)
                {
                    var originalQueryString = request.RequestUri.Query;
                    if (!string.IsNullOrEmpty(originalQueryString))
                    {
                        var ub = new UriBuilder(request.RequestUri) { Query = HttpUtility.UrlDecode(originalQueryString) };
                        request.RequestUri = ub.Uri;
                    }
                }
    
                return base.SendAsync(request, cancellationToken);
            }
        }
 
