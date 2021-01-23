    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var fileSystem = new FileServerOptions
            {
                EnableDirectoryBrowsing = false,
                FileSystem = new PhysicalFileSystem("....")
            };
            app.UseFileServer(fileSystem);
            app.UseNancy();
        }
    }
