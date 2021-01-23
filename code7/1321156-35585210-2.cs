    public class IgnoreQueryStringKeyRoute : RouteBase
    {
        private readonly string queryStringKey;
        public IgnoreQueryStringKeyRoute(string queryStringKey)
        {
            if (string.IsNullOrWhiteSpace(queryStringKey))
                throw new ArgumentNullException("queryStringKey is required");
            this.queryStringKey = queryStringKey;
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request.QueryString.AllKeys.Any(x => x == queryStringKey))
            {
                return new RouteData(this, new StopRoutingHandler());
            }
            // Tell MVC this route did not match
            return null;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            // Tell MVC this route did not match
            return null;
        }
    }
