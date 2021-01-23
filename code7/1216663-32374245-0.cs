    public class BaseController : Controller
	{
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			// Work with a cache here			
			base.OnActionExecuting(filterContext);
		}
    }
