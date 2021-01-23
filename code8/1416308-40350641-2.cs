	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}
		public IConfigurationRoot Configuration { get; }
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.ValueProviderFactories.Insert(0, new MyValueProviderFactory(Configuration.GetSection("MyValueProviderKeyMap")));
			});
		}
	}
