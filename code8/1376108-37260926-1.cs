    public void Configure(IAppBuilder app)
    {
        GlobalHost.DependencyResolver.Register(typeof(ChatHub), () =>
        {
            ChatHub hub = new ChatHub();
            return hub;
        });
        app.MapSignalR();
    }
