       public class Startup
    {
	    public bool IsTesting { get; }
	    public Startup(IHostingEnvironment env)
	    {
		    IsTesting = env.EnvironmentName == "Testing";
	    }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddSingleton<ISomeRepository>(sp => IsTesting ? (ISomeRepository)new SomeRepository() : (ISomeRepository) new FakesomeRepository());
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, ISomeRepository someRepository)
        {
            app.UseIISPlatformHandler();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello World from {nameof(someRepository)}!");
            });
        }
        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
