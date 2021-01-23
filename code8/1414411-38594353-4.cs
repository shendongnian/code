    public class UpdateProductModelBinder : IModelBinder {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext) {
            if (!typeof(UpdateProductModel).IsAssignableFrom(bindingContext.ModelType)) {
                return false;
            }
            //get the content of the body and convert it to model
            object model = null;
            if (actionContext.Request.Content != null)
                model = actionContext.Request.Content.ReadAsAsync(bindingContext.ModelType).Result;
            model = model ?? bindingContext.Model
                ?? Activator.CreateInstance(bindingContext.ModelType);
            // check values provided in the route or query string 
            // for matching properties and set them on the model. 
            // NOTE: this will override any existing value that was already set.
            foreach (var property in bindingContext.PropertyMetadata) {
                var valueProvider = bindingContext.ValueProvider.GetValue(property.Key);
                if (valueProvider != null) {
                    var value = valueProvider.ConvertTo(property.Value.ModelType);
                    var pInfo = bindingContext.ModelType.GetProperty(property.Key);
                    pInfo.SetValue(model, value, new object[] { });
                }
            }
            bindingContext.Model = model;
            return true;
        }
    }
