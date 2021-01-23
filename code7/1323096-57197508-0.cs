    class CustomModelBinder : IModelBinder
    {
        private readonly ICustomService customService;
        public CustomModelBinder(ICustomService customService) => this.customService = customService;
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Use customService during model binding.
        }
    }
