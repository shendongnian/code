    public class DecimalModelBinder : IModelBinder
    {
    	public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    	{
    		ValueProviderResult valueResult = bindingContext.ValueProvider
    			.GetValue(bindingContext.ModelName);
    		ModelState modelState = new ModelState { Value = valueResult };
    		object actualValue = null;
    		if (valueResult.AttemptedValue.Contains(","))
    		{
    			throw new Exception("Some exception");
    		}
    		actualValue = Convert.ToDecimal(valueResult.AttemptedValue,
    		    CultureInfo.CurrentCulture);
    
    		bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
    		bindingContext.Model = actualValue;
    		return true;
    	}
    }
