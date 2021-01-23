    public class CustomAuthenticationMessageHandler : DelegatingHandler
        {
            private static Dictionary<string, String[]> allowedApps = new Dictionary<string, String[]>();
            private readonly string authenticationScheme = "Bearer";
            private readonly string queryStringApiKey = "api_key";
    
            public bool AllowMultiple
            {
                get { return false; }
            }
    
            public CustomAuthenticationMessageHandler()
            {
                if (allowedApps.Count == 0)
                {
                    allowedApps.Add("PetLover_api_key", new[] {"PetLover"});
                    allowedApps.Add("CarOwner_api_key", new[] {"CarOwner"});
                    allowedApps.Add("Admin_api_key", new[] {"PetLover", "CarOwner"});
                }
            }
    
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var req = request;
                Dictionary<string, string> queryStrings = req.GetQueryNameValuePairs().ToDictionary(x => x.Key.ToLower(), x => x.Value);
                string rawAuthzHeader = null;
                if (queryStrings.ContainsKey(queryStringApiKey))
                {
                    rawAuthzHeader = queryStrings[queryStringApiKey];
                }
                else if (req.Headers.Authorization != null && authenticationScheme.Equals(req.Headers.Authorization.Scheme, StringComparison.OrdinalIgnoreCase))
                {
                    rawAuthzHeader = req.Headers.Authorization.Parameter;
                }
                if (rawAuthzHeader != null && allowedApps.ContainsKey(rawAuthzHeader))
                {
                    var currentPrincipal = new GenericPrincipal(new GenericIdentity(rawAuthzHeader), allowedApps[rawAuthzHeader]);
                    request.GetRequestContext().Principal = currentPrincipal;
                }
                else
                {
    
                }
    
                return await base.SendAsync(request, cancellationToken);
            }
        }
    
