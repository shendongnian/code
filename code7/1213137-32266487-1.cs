    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        string _role;
        string _redirect;
        public CustomRedirectFilter(string role, string redirect)
        {
           _role = role;
           _redirect = redirect;
        }
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(CheckDatabaseToCheckUserRole == _role)
            {
                 filterContext.Result = new RedirectResult(_redirect);    
            }
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
