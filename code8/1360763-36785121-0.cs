	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		// Has message bus connection
		services.AddSingleton<ISomeRespository, SomeRepository>();
		
	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(... ISomeRespository db)
	{
