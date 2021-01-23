    public class QueryStringParameterConstraint : IRouteConstraint
    {
        private readonly string queryStringKeyName;
        public QueryStringParameterConstraint(string queryStringKeyName)
        {
            if (string.IsNullOrEmpty(queryStringKeyName))
                throw new ArgumentNullException("queryStringKeyName");
            this.queryStringKeyName = queryStringKeyName;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                return httpContext.Request.QueryString.AllKeys.Contains(this.queryStringKeyName, StringComparer.OrdinalIgnoreCase);
            }
            return true;
        }
    }
