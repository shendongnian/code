    public class GroupNameConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                           RouteValueDictionary values, RouteDirection routeDirection)
        {
            var asm = Assembly.GetExecutingAssembly();
            //Get all the controller names
            var controllerTypes = (from t in asm.GetExportedTypes()
                where typeof(IController).IsAssignableFrom(t)
                select t.Name.Replace("Controller", ""));
            var groupName = values["group"];
            if (groupName != null)
            {
                if (controllerTypes.Any(x => x.Equals(groupName.ToString(),
                                                           StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
            }
            return true;
        }
    }
