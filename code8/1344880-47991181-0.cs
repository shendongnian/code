    public class MyCorsPolicy : Attribute, ICorsPolicyProvider
        {
            public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var policy = new CorsPolicy();
                var requestUri = request.RequestUri;
                var authority = requestUri.Authority.ToLowerInvariant();
                if (authority.EndsWith(".mydomain.com") || authority == "mydomain.com")
                {
                    // returns a url with scheme, host and port(if different than 80/443) without any path or querystring
                    var origin = requestUri.GetComponents(System.UriComponents.SchemeAndServer, System.UriFormat.SafeUnescaped);
                    policy.Origins.Add(origin);
                }
    
                return Task.FromResult(policy);
            }
        }
    
    
        [MyCorsPolicy]
        public class TestController : ApiController
        {
        }
