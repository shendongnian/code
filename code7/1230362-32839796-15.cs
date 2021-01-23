    public static class RouteCollectionExtensions
    {
        public static void MapLocalizedMvcAttributeRoutes(this RouteCollection routes, string urlPrefix, object constraints)
        {
            MapLocalizedMvcAttributeRoutes(routes, urlPrefix, new RouteValueDictionary(constraints));
        }
        public static void MapLocalizedMvcAttributeRoutes(this RouteCollection routes, string urlPrefix, RouteValueDictionary constraints)
        {
            var localizedRouteTable = new RouteCollection();
            // Get a copy of the attribute routes
            localizedRouteTable.MapMvcAttributeRoutes();
            foreach (var rb in localizedRouteTable)
            {
                var route = rb as Route;
                // Add the URL prefix
                route.Url = urlPrefix + route.Url;
                // Add the constraints
                foreach (var constraint in constraints)
                {
                    route.Constraints.Add(constraint.Key, constraint.Value);
                }
                routes.Add(route);
            }
        }
    }
