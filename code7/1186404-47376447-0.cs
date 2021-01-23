	public Startup(IConfiguration configuration)
			{
				Configuration = configuration;
			}
			public IConfiguration Configuration { get; }
			// This method gets called by the runtime. Use this method to add services to the container.
			public void ConfigureServices(IServiceCollection services)
			{
				services.Configure<StorageOptions>(Configuration.GetSection("AzureStorageConfig"));
			}
