    using System.Web;
    using System.Web.Mvc;
    namespace MvcUsernameInUrl
    {
        public class RedirectLoggedOnUserFilter : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var path = filterContext.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(path))
                {
                    // remove the leading slash
                    path = path.Substring(1);
                }
                bool isLoggedIn = filterContext.HttpContext.User.Identity.IsAuthenticated;
                bool requestHasUserName = filterContext.RequestContext.RouteData.Values.ContainsKey("username");
                if (isLoggedIn && !requestHasUserName)
                {
                    var userName = filterContext.HttpContext.User.Identity.Name;
                    filterContext.Result = new RedirectResult("/" + HttpUtility.UrlEncode(userName) + "/" + path);
                }
                else if (!isLoggedIn && requestHasUserName)
                {
                    string newPath = "/";
                    int firstSlashIndex = path.IndexOf("/");
                    if (firstSlashIndex > 0)
                    {
                        newPath = path.Substring(firstSlashIndex);
                    }
                    filterContext.Result = new RedirectResult(newPath);
                }
            }
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                // Do nothing
            }
        }
    }
