    public class SessionIdFilter: ActionFilterAttribute
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionid = filterContext.RouteData.Values["session_id"]; 
            //Check session id against db , if exists return;
                       filterContext.HttpContext.User= new CustomPrincipal("username");//read about custom IPrincipal implementation its easy. 
           
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        { 
           if( !filterContext.HttpContext.User.Identity.IsAuthenticated) 
              { 
                 filterContext.Result = new RedirectResult(loginurl); 
              }
        }
    }
