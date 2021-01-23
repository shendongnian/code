    public class CreateSomethingModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string key = bindingContext.ModelName;
            ValueProviderResult val = bindingContext.ValueProvider.GetValue(key);
            if (val != null)
            {
                string s = val.AttemptedValue as string;
                if (s != null)
                {
                    return new CreateSomething(){Title = s; UserId = new Guid(ControllerContext.HttpContext.Request.Headers["userId"]);}
                }
            }
            return null;
        }
    }
	
