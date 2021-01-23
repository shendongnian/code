    public void Configuration(IAppBuilder app)
    {    
        app.Map("/foo", map =>
        {
            //Specify according to your needs
            var hubConfiguration = new HubConfiguration
            {
               EnableDetailedErrors = true
            };
            map.RunSignalR(hubConfiguration);
        });
        ConfigureAuth(app);
    }
