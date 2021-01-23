    class CustomModelBinderProvider : IModelBinderProvider
    {
        private readonly ICustomService customService;
        public CustomModelBinderProvider(ICustomService customService) => this.customService = customService;
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            // Return CustomModelBinder or null depending on context.
            return new CustomModelBinder(customService);
        }
    }
