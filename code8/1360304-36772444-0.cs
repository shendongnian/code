	public class EtagFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if(IsKnownEtag(filterContext.HttpContext.Request.Headers["If-None-Match"]))
			{
				filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotModified);
			}
		}
		//...
	}
