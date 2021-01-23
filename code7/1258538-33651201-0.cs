    public class SessionTimeOutAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext context = HttpContext.Current;
    
                // check if session supported
                if ( context.Session != null ) {
                    if( context.Session["username"] == null ) {
                       context.Response.Redirect ( "~/Account/Login" );
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }
