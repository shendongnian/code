    public class RedirectAspxPermanentRoute : RouteBase
    {
        private readonly IDictionary<string, string> urlMap;
        public RedirectAspxPermanentRoute(IDictionary<string, string> urlMap)
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
                var destinationUrl = urlMap[path];
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values["controller"] = "System";
                routeData.Values["action"] = "Status301";
                routeData.Values["url"] = destinationUrl;
                return routeData;
            }
            return null;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
