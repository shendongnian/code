    public class SingleCharacterConstraint: IRouteConstraint
    {
        public bool Match
            (
                HttpContextBase httpContext, 
                Route route, 
                string parameterName, 
                RouteValueDictionary values, 
                RouteDirection routeDirection
            )
        {
            if (!values.ContainsKey(parameterName))
              return false;
            var parameterValue = (string)values[parameterName];
            return !string.IsNullOrWhitespace(parameterValue)
              && parameterValue.Length == 1;
        }
    }
