     public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ()  // Check that your user is not an Admin and that your application is "turn-off"
             { 
                filterContext.Result = new HttpStatusCodeResult(403); // or whatever you want
            }
        }
    }
