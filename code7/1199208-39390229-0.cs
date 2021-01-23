    //starup.cs
    public void Configuration(IAppBuilder app)
        {
            Config = new HttpConfiguration();
            WebApiConfig.Register(Config);
            
            app
                .UseResponseLogging()
                .UseRequestLogging()
                .UseHttpErrors()
                .UseExceptionLogging()
                .UseWebApi(Config);
            HandlerConfig.Register(Config);
            SwaggerConfig.Register(Config);
        }
