        public async Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            if (bindingContext.Model == null && // This binder only constructs viewmodels, avoid infinite recursion.
                bindingContext.ModelType.Namespace == "iUS.Benefits.Web.ViewModels" &&
                bindingContext.ModelType.Name.ToLower().Contains("viewmodel"))
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
