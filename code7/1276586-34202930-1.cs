    public void Configure(IApplicationBuilder app)
    {        
       app.UseStaticFiles();
       app.UseDefaultFiles(new Microsoft.AspNet.StaticFiles.DefaultFilesOptions() { DefaultFileNames = new[] { "index.html" } });          
    }
