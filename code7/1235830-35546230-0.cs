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
                Type type = types.FirstOrDefault(t => t.Name.Equals(controller + "Controller", StringComparison.OrdinalIgnoreCase));
                // Ensure the action method exists
                return type != null &&
                       type.GetMethods().Any(x => x.Name.Equals(action, StringComparison.OrdinalIgnoreCase));
            }
            return true;
        }
    }
    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                var action = values["action"] as string;
                var controller = values["controller"] as string;
                var thisAssembly = this.GetType().Assembly;
                Type[] types = thisAssembly.GetTypes();
                Type type = types.FirstOrDefault(t => t.Name .Equals(controller + "Controller", StringComparison.OrdinalIgnoreCase));
                var method = type.GetMethods().FirstOrDefault(x => x.Name.Equals(action, StringComparison.OrdinalIgnoreCase));
                if (type != null && method != null)
                {
                    // Ensure the parameter exists on the action method
                    var param = method.GetParameters().FirstOrDefault(p => p.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));
                    return param != null;
                }
                return false;
            }
            return true;
        }
