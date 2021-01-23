public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(x => x.UseSqlite("Data Source=LocalDatabase.db"));
    ...
}
public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
{
    dataContext.Database.Migrate();
    ...
}
