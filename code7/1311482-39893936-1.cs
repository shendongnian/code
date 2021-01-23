        public static Route MapXmlSitemapRoute(this RouteCollection routes, string name, string url, object defaults, XmlSitemapRouteHandler virtualNodeHandler, object constraints = null, string[] namespaces = null)
        {
            Route route = routes.MapRoute(name, url, defaults, constraints, namespaces);
            route.RouteHandler = virtualNodeHandler;
            return route;
        }
