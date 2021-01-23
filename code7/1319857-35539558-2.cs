	public abstract class BaseController : Controller
	{
		protected override void OnException(ExceptionContext filterContext)
		{
			var responseCode = Response.StatusCode;
			var exception = filterContext.Exception;
			switch (exception.GetType().ToString())
			{
				case "ArgumentNullException":
					responseCode = 601;
					break;
				case "InvalidCastException":
					responseCode = 602;
					break;
			}
			Response.StatusCode = responseCode;
			base.OnException(filterContext);
		}
	}
