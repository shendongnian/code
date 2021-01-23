    /// <summary>
    /// Action filter to require SSL for a protected resource.
    /// </summary>
    /// <remarks>
    /// From http://www.asp.net/web-api/overview/security/working-with-ssl-in-web-api
    /// but modified to support reverse proxies such as Web Farm Framework.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Not possible.")]
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (IsSecure(actionContext.Request))
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                actionContext.Response =
                    new HttpResponseMessage(HttpStatusCode.Forbidden)
                        {
                            ReasonPhrase = "HTTPS Required"
                        };
            }
        }
    
        private static bool IsSecure(HttpRequestMessage request)
        {
            if (request.RequestUri.Scheme == Uri.UriSchemeHttps)
            {
                return true;
            }
    
            IEnumerable<string> headerValues;
    
            if (request.Headers.TryGetValues("X-Forwarded-Proto", out headerValues))
            {
                string protocol = headerValues.FirstOrDefault();
    
                return string.Equals(protocol, "https", StringComparison.OrdinalIgnoreCase);
            }
    
            return false;
        }
    }
