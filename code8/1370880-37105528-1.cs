    public class SpendingAccountSearchParamsModelBinder : IModelBinder {
        public bool BindModel(HttpActionContext controllerContext, ModelBindingContext bindingContext) {
            if (bindingContext.ModelType != typeof(SpendingAccountSearchParams)) {
                return false;
            }
            ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null) {
                //create your default object
                var result = new SpendingAccountSearchParams();
                bindingContext.Model = result;
                return true;
            }
            //you could do other checks and add ModelState errors if needed 
            return true;
        }
    }
