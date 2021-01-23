    public class UriRouter
    {
        public delegate void MethodDelegate(object context, Dictionary<string, string> parameters);
        private readonly Dictionary<string, MethodDelegate> _routes = new Dictionary<string, MethodDelegate>();
        public void DefineRoute(string route, MethodDelegate method)
        {
            _routes.Add(route, method);
        }
        public void Route(string uri, object context)
        {
            foreach (var tuple in _routes)
            {
                var route = tuple.Key;
                // Build RegEx from route (:foo to named group (?<foo>[a-z0-9]+)).
                var routeFormat = new Regex("(:([a-z]+))\\b").Replace(route, "(?<$2>[a-z0-9]+)");
                // Match uri parameter to that regex.
                var routeRegEx = new Regex(routeFormat);
                var match = routeRegEx.Match(uri);
                if (!match.Success)
                {
                    continue;
                }
                // Obtain named groups.
                var result = routeRegEx.GetGroupNames().Skip(1) // Skip the "0" group
                                       .Where(g => match.Groups[g].Success && match.Groups[g].Captures.Count > 0)
                                       .ToDictionary(groupName => groupName, groupName => match.Groups[groupName].Value);
                // Invoke the method
                tuple.Value.Invoke(context, result);
                return;
            }
            // No match found
            throw new Exception("No match found");
        }
    }
