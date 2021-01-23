    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
    }
