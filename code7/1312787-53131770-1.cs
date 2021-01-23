    using AspNetCore.Security.Jwt;
    using Swashbuckle.AspNetCore.Swagger;
    .
    .
    public void ConfigureServices(IServiceCollection services)
    {
		.
		.
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "XXX API", Version = "v1" });
        });
        services.AddSecurity<Authenticator>(this.Configuration, true);
        services.AddMvc().AddSecurity();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        .
		.
		.
        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "XXX API V1");
        });
        app.UseSecurity(true);
        app.UseMvc();
    }
