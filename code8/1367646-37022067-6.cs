	using System.Web;
	using System.Web.Mvc;
	namespace MvcUsernameInUrl
	{
		public class RedirectLoggedOnUserFilter : IActionFilter
		{
			public void OnActionExecuting(ActionExecutingContext filterContext)
			{
				var routeValues = filterContext.RequestContext.RouteData.Values;
				bool isLoggedIn = filterContext.HttpContext.User.Identity.IsAuthenticated;
				bool requestHasUserName = routeValues.ContainsKey("username");
				if (isLoggedIn && !requestHasUserName)
				{
					var userName = filterContext.HttpContext.User.Identity.Name;
					// Add the user name as a route value
					routeValues.Add("username", userName);
					filterContext.Result = new RedirectToRouteResult(routeValues);
				}
				else if (!isLoggedIn && requestHasUserName)
				{
					// Remove the user name as a route value
					routeValues.Remove("username");
					filterContext.Result = new RedirectToRouteResult(routeValues);
				}
			}
			public void OnActionExecuted(ActionExecutedContext filterContext)
			{
				// Do nothing
			}
		}
	}
