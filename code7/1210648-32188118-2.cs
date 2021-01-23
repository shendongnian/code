    public class CheckForLogoutAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
			// filterContext.HttpContext may be needed for request/response
            // If using the global filter setup, be sure to confirm user is logged in first
        }
    }
	
