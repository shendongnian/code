	public void Configure(IApplicationBuilder app)
	{
		app.UseInMemorySession(configure: s => s.IdleTimeout = TimeSpan.FromMinutes(30));
		app.UseMvc();
	}
