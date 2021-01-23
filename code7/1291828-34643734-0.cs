    public void Configure(IApplicationBuilder app)
    {
       // other configuration code
    
       app.UseMvc(routes =>
       {
            routes.UseTypedRouting();
       });
    }
