    public class SessionActiveFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var activeSession = Session["user"];
                if (activeSession == null)
                    //Here, do a redirect
    
                base.OnActionExecuting(filterContext);
            }
        }
