    public virtual void Configuration(IAppBuilder app)
    {
        var staticFilesOptions = new StaticFileOptions
        {
            FileSystem = new VirtualFileSystem()
        };
        app.UseStaticFiles(staticFilesOptions);
    }
