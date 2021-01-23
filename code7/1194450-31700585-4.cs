    public class MyCatConstraint : IRouteConstraint
    {
        // suppose this is your cats list. In the real world a DB provider 
        private string[] _myCats = new[] { "cat1", "cat2", "cat3" };
        
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // return true if you found a match on your cat's list otherwise false
            // in the real world you could query from DB to match cats instead of searching from the array.  
            if(values.ContainsKey(parameterName))
            {
                return _myCats.Any(c => c == values[parameterName].ToString());
            }
            return false;
        }
    }
