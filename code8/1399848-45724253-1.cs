		public class Startup
		{
			public Startup(IConfiguration configuration)
			{
				Configuration = configuration;
			}
			public IConfiguration Configuration { get; }
			// This method gets called by the runtime. Use this method to add services to the container.
			public void ConfigureServices(IServiceCollection services)
			{
				services.AddMvc();
				
				// Authentication service
				JwtAuthentication.AddJwtAuthentication(services);
				services.AddQuartz(); // <======== THIS LINE
				services.AddSingleton<IHttpRequestScheduler, HttpRequestScheduler>();
			}
			// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
			public void Configure(IApplicationBuilder app, 
								  IHostingEnvironment env, 
								  ILoggerFactory loggerFactory,
								  IApplicationLifetime lifetime)
			{
				if (env.IsDevelopment())
				{
					app.UseDeveloperExceptionPage();
				}
				app.UseMvc();
				app.UseAuthentication();
				// Add JWT generation endpoint:
				var options = new TokenProviderOptions
				{
					Audience = "ExampleAudience",
					Issuer = "ExampleIssuer",
					SigningCredentials = new SigningCredentials(JwtAuthentication.SIGNING_KEY, SecurityAlgorithms.HmacSha256),
				};
				app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
				app.UseQuartz(); // <======== THIS LINE
			}
		}
