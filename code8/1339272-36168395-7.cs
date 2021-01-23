    public class RedirectAspxPermanentRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var path = httpContext.Request.Path;
            if (path.EndsWith(".aspx"))
            {
                // Remove the .aspx extension
                var destinationUrl = path.Substring(0, path.Length - 5);
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
