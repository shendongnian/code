    public class RedirectAspxPermanentRoute : RouteBase
    {
        private readonly IDictionary<string, object> urlMap;
        public RedirectAspxPermanentRoute(IDictionary<string, object> urlMap)
        {
            if (urlMap == null)
                throw new ArgumentNullException("urlMap");
            this.urlMap = urlMap;
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var path = httpContext.Request.Path;
            if (path.EndsWith(".aspx"))
            {
                if (!urlMap.ContainsKey(path))
                    return null;
                var routeValues = urlMap[path];
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values["controller"] = "System";
                routeData.Values["action"] = "Status301";
                routeData.DataTokens["routeValues"] = routeValues;
                return routeData;
            }
            return null;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
