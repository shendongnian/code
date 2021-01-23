    public void ConfigureServices(IServiceCollection services) {
        services.AddDataProtection();
        services.ConfigureDataProtection(options => {
            options.PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
        });
    }
