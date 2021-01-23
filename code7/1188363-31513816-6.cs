	public class BaseController : Controller
	{                
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
            string actionName = filterContext.ActionDescriptor.ActionName;
			if( Request.Params["dev"] != "something" && !String.Compare(actionName, "MaintenancePage", StringComparison.InvariantCultureIgnoreCase))
			{
				filterContext.Result = RedirectToAction("MaintenancePage");
			}
		}
		public ActionResult MaintenancePage()
		{
			return View();
		}
	}
