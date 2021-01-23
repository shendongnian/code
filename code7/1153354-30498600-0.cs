    public void Configure(IApplicationBuilder app)
       {
          // Add Mvc to the pipeline.
          app.UseMvc();
    
          // Add the welcome page to the pipeline.
          app.UseWelcomePage();
       }
    
       public void ConfigureServices(IServiceCollection services)
       {
          // Add all dependencies needed by Mvc.
          services.AddMvc();
    
          // Add EmailService to the collection. When an instance is needed,
          // the framework injects this instance to the objects that needs it
          services.AddSingleton<IEmailService, EmailService>();
       }
