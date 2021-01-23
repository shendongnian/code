	public class BaseController : Controller
	{                
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
            string actionName = filterContext.ActionDescriptor.ActionName;
			if( Request.Params["dev"] != "something" && actionName != "MaintenancePage")
			{
				filterContext.Result = RedirectToAction("MaintenancePage");
			}
		}
		public ActionResult MaintenancePage()
		{
			return View();
		}
	}
