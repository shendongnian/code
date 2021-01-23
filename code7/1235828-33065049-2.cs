    public class ParameterExistsConstraint : IRouteConstraint
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
                var method = type.GetMethod(action);
                if (type != null && method != null)
                {
                    // Ensure the parameter exists on the action method
                    var param = method.GetParameters().Where(p => p.Name == parameterName).FirstOrDefault();
                    return param != null;
                }
                return false;
            }
            return true;
        }
    }
