    public class SampleRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var path = httpContext.Request.Path.Substring(1);
            if (path.Equals("the/virtual/path"))
            {
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values["user"] = "TheUser";
                routeData.Values["controller"] = "Home";
                routeData.Values["action"] = "Custom";
                routeData.Values["RouteModels"] = new List<RouteModel> { new RouteModel { Name = "Foo" }, new RouteModel { Name = "Bar" } };
                routeData.DataTokens["MetaData"] = "SomeMetadata";
                return routeData;
            }
            return null;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            string user = values["user"] as string;
            string controller = values["controller"] as string;
            string action = values["action"] as string;
            IEnumerable<RouteModel> routeModels = values["RouteModels"] as IEnumerable<RouteModel>;
            if ("TheUser".Equals(user) && "Home".Equals(controller) && "Custom".Equals(action))
            {
                // Use the route models to either complete the match or to do something else.
                return new VirtualPathData(this, "the/virtual/path");
            }
            return null;
        }
        private class RouteModel
        {
            public string Name { get; set; }
        }
    }
