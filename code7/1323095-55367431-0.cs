    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // dependency injection
            var model = bindingContext.HttpContext.RequestServices.GetService(bindingContext.ModelType);
            // other changes...
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
