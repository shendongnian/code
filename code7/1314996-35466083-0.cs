	public class CustomModelBinder : DefaultModelBinder
	{
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult result;
			try
			{
				result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			}
			catch (Exception ex)
			{
				bindingContext.ModelState.AddModelError(bindingContext.ModelName, $"The field {bindingContext.ModelMetadata.DisplayName} contains bad data.");
				return bindingContext.Model;
			}
			if (bindingContext.ModelName == "MyNumber" || bindingContext.ModelName == "MyNumber2")
			{
				return StripAndBindModel(bindingContext, result);
			}
			return base.BindModel(controllerContext, bindingContext);
		}
		private object StripAndBindModel(ModelBindingContext bindingContext, ValueProviderResult result)
		{
			var strippedInput = result.AttemptedValue.Replace("#", string.Empty);
			int value;
			if (int.TryParse(strippedInput, out value))
			{
				return value;
			}
			bindingContext.ModelState.AddModelError(bindingContext.ModelName, $"The field {bindingContext.ModelMetadata.DisplayName} must be a valid number.");
			bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result);
			return bindingContext.Model;
		}
	}
