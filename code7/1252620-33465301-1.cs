    public void Configuration(IAppBuilder app)
    {
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index")
            });
    
            //...
    
            app.MapSignalR();    
    }
