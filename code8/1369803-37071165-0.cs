    public class UriRouteParser
    {
        private readonly string[] _routes;
        public UriRouteParser(IEnumerable<string> routes)
        {
            _routes = routes.ToArray();
        }
        public Dictionary<string, string> GetRouteValues(string uri)
        {
            foreach (var route in _routes)
            {
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
                return result;
            }
            // No match found
            return null;
        }
    }
