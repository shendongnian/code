    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("MyPolicy");
        // ...
    }
