	public class OptionalClassInstanceBinder : DefaultModelBinder
	{
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			bindingContext.FallbackToEmptyPrefix = false;
			return base.BindModel(controllerContext, bindingContext);
		}
	}
	[ModelBinder(typeof(OptionalClassInstanceBinder))]
	public class CustomFilterModel
	{
		...
	}
