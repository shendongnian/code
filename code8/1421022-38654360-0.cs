    public class PriceModelBinder : IModelBinder
    {
    	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    		ModelState modelState = new ModelState { Value = value };
    		decimal result = 0.0M;
    		if (!decimal.TryParse(value.AttemptedValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out result))
    			modelState.Errors.Add(new FormatException("Price is not valid"));
    		return result;
    	}
    }
