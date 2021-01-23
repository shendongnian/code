    public IConfigurationRoot Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // http://developer.telerik.com/featured/new-configuration-model-asp-net-core/
        // services.Configure<SmtpConfig>(Configuration.GetSection("Smtp"));
        Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<SmtpConfig>(services, Configuration.GetSection("Smtp"));
