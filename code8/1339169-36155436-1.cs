    public class NoApiControllerConstraint : IRouteConstraint
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
            return values["controller"] != "api";
        }
    }
    routes.MapRoute(
            "Default",
            "{controller}/{action}",
            new {controller="Home"},
            new {isNotForApi=new NoApiControllerConstraint()}
    );
