    public class MyCons : IRouteConstraint
    {
        private ClassA classA = new Class();
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return classA.IsThisTrue();
        }
    }
