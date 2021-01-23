    public class AuthorizationAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
    
    
    
                if (!AllowedToAccess()) // if not in specific role show page with message that user is unauthorized to view this page
                {
                    string redirectUrl = string.Format("?returnUrl={0}", filterContext.HttpContext.Request.Url.PathAndQuery);
    
                    filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl + redirectUrl, true);
                }
                else
                {
                    base.OnActionExecuting(filterContext); if authorized user allow it to view
                }
            }
