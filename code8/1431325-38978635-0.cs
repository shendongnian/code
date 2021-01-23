    public class AliasConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
        	var alias = values[parameterName];
            // Assume, that I already have dictionary of handles and ids for them
            var publicHandlesDictionary = SomeStaticClass.Dic;
            if (publicHandlesDictionary.ContainsValue(alias))
            {
                //adding encId as route parameter
                values["id"] = SomeHelper.Encrypt(publicHandlesDictionary.FirstOrDefault(x => x.Value == alias).Key);
                return true;
            }
            return false;
        }
    }	
    
    //for all alias routes
    routes.MapRoute(
        name: "Alias",
        url: "{*alias}",
        defaults: new {controller = "MyController", action = "Index"},
        constraints: new { alias = new AliasConstraint() }
    );
    //for all other default operations
    routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );
