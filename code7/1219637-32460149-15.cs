    public void Configure(
        IApplicationBuilder application,
        IWebHostEnvironment webHostEnvironment)
    {
        app.ApplicationServices.GetService<MyService>();
    }
