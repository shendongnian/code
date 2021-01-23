    public class EmptyStringToNullModelBinder : Attribute, IModelBinder
	{
		public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			bindingContext.Model = string.IsNullOrWhiteSpace(valueResult?.RawValue?.ToString()) ? null : valueResult.RawValue;
			return true;
		}
	}
