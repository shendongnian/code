    public class VerbConstraint : IHttpRouteConstraint
    {
        private HttpMethod _method;
        public VerbConstraint(HttpMethod method)
        {
            _method = method;
        }
        public bool Match(HttpRequestMessage request,
                          IHttpRoute route,
                          string parameterName,
                          IDictionary<string, object> values,
                          HttpRouteDirection routeDirection)
        {
            if (request.Method == _method)
            {
                return true;
            }
            return false;
        }
    }
