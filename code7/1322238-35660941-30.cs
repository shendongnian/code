    public class IoCModelBinder : IModelBinder
    {
        public async Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {   // For reference: https://github.com/aspnet/Mvc/issues/4196
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            if (bindingContext.Model == null && // This binder only constructs viewmodels, avoid infinite recursion.
                    (
                        (bindingContext.ModelType.Namespace.StartsWith("OUR.SOLUTION.Web.ViewModels") && bindingContext.ModelType.IsClass)
                            ||
                        (bindingContext.ModelType.IsInterface)
                    )
                )
            {
                var serviceProvider = bindingContext.OperationBindingContext.HttpContext.RequestServices;
                var model = serviceProvider.GetRequiredService(bindingContext.ModelType);
                // Call model binding recursively to set properties
                bindingContext.Model = model;
                var result = await bindingContext.OperationBindingContext.ModelBinder.BindModelAsync(bindingContext);
                bindingContext.ValidationState[model] = new ValidationStateEntry() { SuppressValidation = true };
                return result;
            }
            return await ModelBindingResult.NoResultAsync;
        }
    }
