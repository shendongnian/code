    class CustomModelBinderConfigureMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly ICustomService customService;
        public CustomModelBinderConfigureMvcOptions(ICustomService customService) => this.customService = customService;
        public void Configure(MvcOptions options)
            => options.ModelBinderProviders.Add(new CustomModelBinderProvider(customService));
    }
