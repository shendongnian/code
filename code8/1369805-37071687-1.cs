    public class UriRouter
    {
        // Delegate with a context object and the route parameters as parameters
        public delegate void MethodDelegate(object context, Dictionary<string, string> parameters);
        // Internal class storage for route definitions
        protected class RouteDefinition
        {
            public MethodDelegate Method;
            public string RoutePath;
            public Regex RouteRegEx;
            public RouteDefinition(string route, MethodDelegate method)
            {
                RoutePath = route;
                Method = method;
                
                // Build RegEx from route (:foo to named group (?<foo>[a-z0-9]+)).
                var routeFormat = new Regex("(:([a-z]+))\\b").Replace(route, "(?<$2>[a-z0-9]+)");
                // Build the match uri parameter to that regex.
                RouteRegEx = new Regex(routeFormat);
            }
        }
        
        private readonly List<RouteDefinition> _routes;
        public UriRouter()
        {
            _routes = new List<RouteDefinition>();
        }
        public void DefineRoute(string route, MethodDelegate method)
        {
            _routes.Add(new RouteDefinition(route, method));
        }
        public void Route(string uri, object context)
        {
            foreach (var route in _routes)
            {
                // Execute the regex to check whether the uri correspond to the route
                var match = route.RouteRegEx.Match(uri);
                if (!match.Success)
                {
                    continue;
                }
                // Obtain named groups.
                var result = route.RouteRegEx.GetGroupNames().Skip(1) // Skip the "0" group
                                       .Where(g => match.Groups[g].Success && match.Groups[g].Captures.Count > 0)
                                       .ToDictionary(groupName => groupName, groupName => match.Groups[groupName].Value);
                // Invoke the method
                route.Method.Invoke(context, result);
                // Only the first match is executed
                return;
            }
            // No match found
            throw new Exception("No match found");
        }
    }
