	public class BaseController : Controller
	{                
		private override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if( Request.Params[ "dev" ] != "something" )
			{
				filterContext.Result = RedirectToAction( "MaintenancePage");
			}
		}
		public ActionResult MaintenancePage()
		{
			return View();
		}
	}
