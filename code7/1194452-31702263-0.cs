    public class NotEqual : IRouteConstraint
    {
        private string[] _match = null;
        public NotEqual(string[] match)
        {
            _match = match;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            foreach(var controllername in _match)
            {
                if (String.Compare(values[parameterName].ToString(), controllername, true) == 0)
                    return false;
            }
            return true;
        }
    }
