	public class Startup
	{
		public ModuleProvider ModuleProvider = new ModuleProvider();
		public void ConfigureServices(IServiceCollection services)
		{
			var descriptors = ModuleProvider.GetModules() // Ordered
				.SelectMany(m => m.GetServices());
				
			// Apply descriptors to services.
		}
		public void Configure(IApplicationBuilder app)
		{
			var modules = ModuleProvider.GetModules(); // Ordered.
			// Startup code.
		}
	}
