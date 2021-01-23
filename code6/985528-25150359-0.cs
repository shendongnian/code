    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new DisableBundlingForAdminFilter());
            // other filters
        }
        private class DisableBundlingForAdminFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
				#if !DEBUG
                BundleTable.EnableOptimizations = !filterContext.HttpContext.User.IsInRole("Admin");
				#endif
            }
        }
    }
	
