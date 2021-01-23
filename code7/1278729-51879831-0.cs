    public class Startup 
    {
        public static string ConnectionString {get; private set;}
    
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
               if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }
                ConnectionString = Configuration.GetConnectionString("xxxxxx");
                app.UseMvc();
    }
