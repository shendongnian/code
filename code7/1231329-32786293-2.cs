    public class MyCons : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            ClassA classA = new Class();
            return classA.IsThisTrue();
        }
    }
