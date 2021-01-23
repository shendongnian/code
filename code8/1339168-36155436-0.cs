    public class LocalhostConstraint : IRouteConstraint
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
            return httpContext.Request.IsLocal;
        }
    }
    routes.MapRoute(
            "Admin",
            "Admin/{action}",
            new {controller="Admin"},
            new {isLocal=new LocalhostConstraint()}
    );
