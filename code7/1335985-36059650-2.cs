    public class SwitcherRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData result = null;
            // Trim the leading slash
            var path = httpContext.Request.Path.Substring(1);
            // Check that the request is what you are interested in
            if (path.Equals("home/about", StringComparison.OrdinalIgnoreCase))
            {
                result = new RouteData(this, new MvcRouteHandler());
                if (/* some (preferably cached) condition */)
                {
                    result.Values["controller"] = "Home";
                    result.Values["action"] = "About";
                } 
                else 
                {
                    result.Values["controller"] = "Alternate";
                    result.Values["action"] = "About";
                }
            }
            // IMPORTANT: Always return null if there is no match.
            // This tells .NET routing to check the next route that is registered.
            return result;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;
            var controller = Convert.ToString(values["controller"]);
            var action = Convert.ToString(values["action"]);
            if (action.Equals("About", StringComparison.OrdinalIgnoreCase))
            {
                if (controller.Equals("Home", StringComparison.OrdinalIgnoreCase) || 
                    controller.Equals("Alternate", StringComparison.OrdinalIgnoreCase))
                {
                    return new VirtualPathData(this, "home/about");
                }
            }
            // IMPORTANT: Always return null if there is no match.
            // This tells .NET routing to check the next route that is registered.
            return result;
        }
    }
