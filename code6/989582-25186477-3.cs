    public static class HttpRouteCollectionExtensions
    {
        public static IHttpRoute MapHttpRouteAt(this HttpRouteCollection routes, int index, string name, string routeTemplate, object defaults = null, object constraints = null, HttpMessageHandler handler = null)
        {
            Contract.Requires(routes != null);
            IHttpRoute route = routes.MapHttpRoute(name, routeTemplate, defaults, constraints, handler);
            RouteBase apiRoute = RouteTable.Routes[RouteTable.Routes.Count - 1];
            RouteTable.Routes.Remove(apiRoute);
            RouteTable.Routes.Insert(index, apiRoute);
            return route;
        }
    }
