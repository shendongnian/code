    public class CategoryRouteConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                if (routeDirection == RouteDirection.UrlGeneration)
                    return true;
    
                if (string.Equals(parameterName, "categoryName", StringComparison.OrdinalIgnoreCase))
                {
                    //return true if (string)values[parameterName] == "known category name"
                }
    
                return false;
            }
        }
