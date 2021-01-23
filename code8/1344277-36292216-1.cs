    public void ConfigureServices(IServiceCollection services)
    {
        Configure(...).Wait();
    }
    
    public async Task Configure(Seeder seeder)
    {
    ...
    await seeder.Seed();
    ...
    }
