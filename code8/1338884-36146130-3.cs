    namespace Web.Contraints {
		public class BrochureConstraint : IRouteConstraint {
			public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
				//Create our 'fake' controllerContext as we cannot access ControllerContext here
				HttpContextWrapper context = new HttpContextWrapper(HttpContext.Current);
				RouteData routeData = new RouteData();
				routeData.Values.Add("controller", "brochure");
				ControllerContext controllerContext = new ControllerContext(new RequestContext(context, routeData), new BrochureController());
				//Check if our view exists in the folder -> if so the route is valid - return true
				ViewEngineResult result = ViewEngines.Engines.FindView(controllerContext, "~/Areas/Brochure/Views/Brochure/" + values["id"] + ".cshtml", null);
				return result.View != null;
			}
		}
	}
    namespace Web {
        public class MvcApplication : System.Web.HttpApplication {
    		//If view doesnt exist then url is a client so use the 'HomeDefault' route below
            routes.MapRoute(
                name: "Brochure",
                url: "{id}",
                defaults: new { controller = "brochure", action = "Brochure", id = "Index" },
                namespaces: new[] { "Web.Areas.Brochure.Controllers" },
                constraints: new { isBrochure = new BrochureConstraint() }
            );
    
            //This is home page for client
            routes.MapRoute(
                name: "HomeDefault",
                url: "{client}/{action}",
                defaults: new { controller = "home", action = "index" },
                namespaces: new string[] { "Web.Controllers" }
            );
    	}
    }
