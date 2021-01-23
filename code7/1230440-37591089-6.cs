    public static class RouteCollectionExtensions
    {
        public static void MapLocalizedMvcAttributeRoutes(this RouteCollection routes, string defaultCulture)
        {
            var routeProvider = new LocalizeDirectRouteProvider(
                "{culture}/", 
                defaultCulture
                );
            routes.MapMvcAttributeRoutes(routeProvider);
        }
    }
    class LocalizeDirectRouteProvider : DefaultDirectRouteProvider
    {
        ILogger _log = LogManager.GetCurrentClassLogger();
        string _urlPrefix;
        string _defaultCulture;
        RouteValueDictionary _constraints;
        public LocalizeDirectRouteProvider(string urlPrefix, string defaultCulture)
        {
            _urlPrefix = urlPrefix;
            _defaultCulture = defaultCulture;
            _constraints = new RouteValueDictionary() { { "culture", new CultureConstraint(defaultCulture: defaultCulture) } };
        }
        protected override IReadOnlyList<RouteEntry> GetActionDirectRoutes(
                    ActionDescriptor actionDescriptor,
                    IReadOnlyList<IDirectRouteFactory> factories,
                    IInlineConstraintResolver constraintResolver)
        {
            var originalEntries = base.GetActionDirectRoutes(actionDescriptor, factories, constraintResolver);
            var finalEntries = new List<RouteEntry>();
            foreach (RouteEntry originalEntry in originalEntries)
            {
                var localizedRoute = CreateLocalizedRoute(originalEntry.Route, _urlPrefix, _constraints);
                var localizedRouteEntry = CreateLocalizedRouteEntry(originalEntry.Name, localizedRoute);
                finalEntries.Add(localizedRouteEntry);
                originalEntry.Route.Defaults.Add("culture", _defaultCulture);
                finalEntries.Add(originalEntry);
            }
            return finalEntries;
        }
        private Route CreateLocalizedRoute(Route route, string urlPrefix, RouteValueDictionary constraints)
        {
            // Add the URL prefix
            var routeUrl = urlPrefix + route.Url;
            // Combine the constraints
            var routeConstraints = new RouteValueDictionary(constraints);
            foreach (var constraint in route.Constraints)
            {
                routeConstraints.Add(constraint.Key, constraint.Value);
            }
            return new Route(routeUrl, route.Defaults, routeConstraints, route.DataTokens, route.RouteHandler);
        }
        private RouteEntry CreateLocalizedRouteEntry(string name, Route route)
        {
            var localizedRouteEntryName = string.IsNullOrEmpty(name) ? null : name + "_Localized";
            return new RouteEntry(localizedRouteEntryName, route);
        }
    }
