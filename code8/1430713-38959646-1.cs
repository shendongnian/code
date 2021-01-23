    public class AdminUserValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.Current.IsAdmin == false)
            {
                //Prevent access to the controller's method and show error page (bad request/forbidden)
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            base.OnActionExecuting(filterContext);
        }
    }
