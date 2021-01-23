	public class Action1DebugActionWebApiFilter : IActionFilter
	{
		private readonly IMyclass myClass;
		
		public Action1DebugActionWebApiFilter(IMyClass myClass)
		{
			if (myClass == null)
				throw new ArgumentNullException("myClass");
			this.myClass = myClass;
		}
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (this.IsFilterDefined(actionContext.ActionDescriptor))
			{
				// pre-processing
				Debug.WriteLine("ACTION 1 DEBUG pre-processing logging");
			}
		}
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			if (this.IsFilterDefined(actionExecutedContext.ActionDescriptor))
			{
				var objectContent = actionExecutedContext.Response.Content as ObjectContent;
				if (objectContent != null)
				{
					var type = objectContent.ObjectType; //type of the returned object
					var value = objectContent.Value; //holding the returned value
				}
				Debug.WriteLine("ACTION 1 DEBUG  OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
			}
		}
		
		private bool IsFilterDefined(ActionDescriptor actionDescriptor)
		{
			return actionDescriptor.IsDefined(typeof(Action1DebugAttribute), inherit: true)
				|| actionDescriptor.ControllerDescriptor.IsDefined(typeof(Action1DebugAttribute), inherit: true);
		}
	}
