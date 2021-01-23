	public void OnActionExecuting(ActionExecutingContext context)
	{
		foreach (ControllerParameterDescriptor param in context.ActionDescriptor.Parameters) {
			if (param.ParameterInfo.CustomAttributes.Any(
				attr => attr.AttributeType == typeof(FromBodyAttribute))
			) {
				var argument = context.ActionArguments.FirstOrDefault(
					arg => arg.Value?.GetType() == param.ParameterType
				);
				var entity = argument.Value;
				
				// do something with your entity...
