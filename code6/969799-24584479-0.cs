    public class ChangePasswordRequiredActionFilter: IActionFilter
    {
        #region Implementation of IActionFilter
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Now you have to put your custom logic here, this is example:
                User user = ourService.GetUser(blablabla);
                if (user != null && !user.ChangePassword)
                {
                    if (currentUrl != "/Account/ChangePassword" && currentUrl != "/Account/LogOff")
                    {
                        filterContext.Result = new RedirectResult("/Account/ChangePassword");
                    }
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
        #endregion
    }
