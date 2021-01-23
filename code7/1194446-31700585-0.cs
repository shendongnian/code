    public class MyCatConstraint : IRouteConstraint
    {
        // suppose this is your cats list. a simple database
        private string[] _myCats = new[] { "cat1", "cat2", "cat3" };
        
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(values.ContainsKey(parameterName))
            {
                return _myCats.Any(c => c == values[parameterName].ToString());
            }
            return false;
        }
    }
