    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("MyPolicy");
        // ...
        // This should always be called last to ensure that
        // middleware is registered in the correct order.
        app.UseMvc();
    }
