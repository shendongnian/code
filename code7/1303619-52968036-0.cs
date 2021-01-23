    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        ConnectionManager.SetConfig(Configuration);
    }
