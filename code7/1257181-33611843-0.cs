    public void Configuration(IAppBuilder app)
    {
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        //ConfigureAuth(app);
        HttpConfiguration config = new HttpConfiguration();
        WebApiConfig.Register(config);
        
        app.UseWebApi(config);  
        ConfigureAuth(app); 
    }
