    public class IoCModelBinder : IModelBinder
    {
        public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {
            var serviceProvider = bindingContext.OperationBindingContext.HttpContext.RequestServices;
            var model = serviceProvider.GetService(bindingContext.ModelType);
            bindingContext.Model = model;
            var binder = new GenericModelBinder();
            return binder.BindModelAsync(bindingContext);
        }
    }
