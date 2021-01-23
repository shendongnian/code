	public class CurrencyCheckAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
            // Put your logic and potential redirect here.
		}
	}
