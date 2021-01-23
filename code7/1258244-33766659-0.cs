    public class AuthorizationTokenCapturingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue header = request.Headers.Authorization;
            if (header != null)
            {
                HeaderBucket bucket = (HeaderBucket)request.GetDependencyScope().GetService(typeof(HeaderBucket));
                bucket.Add(new HeaderBucket.Header(HeaderConstants.AUTHORIZATION_TOKEN, header.Parameter));
            }
    
            return base.SendAsync(request, cancellationToken);
        }
    }
