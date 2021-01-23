    public class MyAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           //do authorization here     
     
            base.OnActionExecuting(filterContext);
    
            // Create object parameter.
            filterContext.ActionParameters["userdata"] = new User("John", "Smith");
           
        }
    }
