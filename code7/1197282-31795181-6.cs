    public class MyCatConstraint : IRouteConstraint
    {
        // suppose this is your username list. In the real world a DB provider 
        private string[] _myUsernames = new[] { "user1", "user2", "user3" };
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // return true if you found a match on your user's list otherwise false
            // in the real world you could query from DB to match cats instead of searching from the array.  
            if(values.ContainsKey(parameterName))
            {
                return _myUsernames.Any(c => c == values[parameterName].ToString());
            }
            return false;
        }
    }
