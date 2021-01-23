    public class WildcardOriginCorsPolicy : Attribute, ICorsPolicyProvider
        {
            private readonly string _origins;
            private readonly string _headers;
            private readonly string _methods;
    
            //private readonly CorsPolicy _policy;
            //
            // Summary:
            //     Initializes a new instance of the WildcardOriginCorsPolicy class.
            //
            // Parameters:
            //   origins:
            //     Comma-separated list of origins that are allowed to access the resource. Use
            //     "*" to allow all.
            //     "*.example.com" for subdomains
            //
            //   headers:
            //     Comma-separated list of headers that are supported by the resource. Use "*" to
            //     allow all. Use null or empty string to allow none.
            //
            //   methods:
            //     Comma-separated list of methods that are supported by the resource. Use "*" to
            //     allow all. Use null or empty string to allow none.
            public WildcardOriginCorsPolicy(string origins, string headers, string methods)
            {
                this._origins = origins;
                this._headers = headers;
                this._methods = methods;
            }
    
            public bool SupportsCredentials { get; set; }
    
            public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var policy = CreatePolicy(request.GetCorsRequestContext(), this._origins, this._headers, this._methods);
                policy.SupportsCredentials = this.SupportsCredentials;
    
                return Task.FromResult(policy);
            }
    
            private static CorsPolicy CreatePolicy(CorsRequestContext requestContext, string origins, string headers, string methods)
            {
    
                var corsPolicy = new CorsPolicy();
                if (origins == "*")
                {
                    corsPolicy.AllowAnyOrigin = true;
                }
                else
                {
                    var originsStringArray = origins.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var requestOrigin = requestContext.Origin.ToLowerInvariant();
    
                    foreach (var originItem in originsStringArray)
                    {
                        ////Check if the current request uri matches with any of the wildcard origins.
                        if (Regex.IsMatch(requestOrigin, WildCardToRegularExpression(originItem)))
                        {
                            corsPolicy.Origins.Add(requestOrigin);
                        }
                    }
                }
    
                if (!String.IsNullOrEmpty(headers))
                {
                    if (headers == "*")
                    {
                        corsPolicy.AllowAnyHeader = true;
                    }
                    else
                    {
                        var headersStringArray = headers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        corsPolicy.Headers.AddAll(headersStringArray);
                    }
                }
    
                if (!String.IsNullOrEmpty(methods))
                {
                    if (methods == "*")
                    {
                        corsPolicy.AllowAnyMethod = true;
                    }
                    else
                    {
                        var methodsStringArray = methods.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        corsPolicy.Methods.AddAll(methodsStringArray);
                    }
                }
    
                return corsPolicy;
            }
    
            private static string WildCardToRegularExpression(String value)
            {
                return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
            }
        }
