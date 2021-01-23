    public class CustomAuthorizationFilter : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          
            //your authorization code goes here.
            base.OnActionExecuting(filterContext);
        }
 
 
    }
