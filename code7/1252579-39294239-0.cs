    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //...
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services
                .AddMvc(mvcOptions =>
                {
                    IServiceProvider provider = services.BuildServiceProvider();
                    IStringLocalizer localizer = provider.GetService<IStringLocalizer<DisplayResources>>();
                    mvcOptions.ModelMetadataDetailsProviders.Add(new DisplayAttributeLocalizationProvider(localizer));
                });
            //...
        }
    }
