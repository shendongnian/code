    public class Startup
    {      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {           
          
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            Settings.Configure(httpContextAccessor);
        }
    }
