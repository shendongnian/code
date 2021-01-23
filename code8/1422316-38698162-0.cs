    public class BaseController : Controller
        {
    		
    		protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var getControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var getActionName = filterContext.ActionDescriptor.ActionName;
                //Write your code here
            }
    	}
