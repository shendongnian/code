    public class VerifyUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["UserID"];
            if (user == null)
                filterContext.Result = new RedirectResult(string.Format("/User/Login?targetUrl={0}",filterContext.HttpContext.Request.Url.AbsolutePath));
        }
    }
