        public class YourCustomFilter : IFilterProvider
        {
            public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
            {
                List<Filter> result = new List<Filter>();
    
                var routeData = controllerContext.HttpContext.Request.RequestContext.RouteData;
                var controller = routeData.GetRequiredString("controller");
                var action = routeData.GetRequiredString("action");
    
                if (controller != "livecontrollername" && action != "liveactionname")
                {
                    result.Add(new Filter(new YourCustomAuthorizeAttribute(), FilterScope.Global, null));
                }
    
                return result;
            }
        }
    
        public class YourCustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
        { 
            //Do something to prevent user from accessing the controller here
        }
