    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext.Session["UserType"] != null)
            {
                if (Convert.ToString(filterContext.HttpContext.Session["UserType"]) == "3")
                {
                    filterContext.RouteData.Values["controller"] = "Login";
                    filterContext.RouteData.Values["action"] = "ChangePassword";
                }
            }
        }
    }
