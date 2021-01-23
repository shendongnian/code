    public void Configuration(IAppBuilder app)
    {
        HubConfiguration config = new HubConfiguration();
        config.EnableJSONP = true;
        app.MapSignalR(config);
    }
