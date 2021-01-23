    public class ActionExistsConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                var action = values["action"] as string;
                var controller = values["controller"] as string;
                var thisAssembly = this.GetType().Assembly;
                Type[] types = thisAssembly.GetTypes();
                Type type = types.Where(t => t.Name == (controller + "Controller")).SingleOrDefault();
                // Ensure the action method exists
                return type != null && type.GetMethod(action) != null;
            }
            return true;
        }
    }
