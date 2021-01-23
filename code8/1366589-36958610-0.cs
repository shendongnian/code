	public class Startup
	{
		...
		
		public void Configure(IApplicationBuilder applicationBuilder, ...)
		{
			...
			// NOTE: this must go at the end of Configure
			var serviceScopeFactory = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
			using (var serviceScope = serviceScopeFactory.CreateScope())
			{
				var dbContext = serviceScope.ServiceProvider.GetService<MyDbContext>();
				dbContext.Database.EnsureCreated();
			}
		}
	}
