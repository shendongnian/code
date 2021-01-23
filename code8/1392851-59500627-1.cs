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
More details and links to full code samples available at https://jasonwatmore.com/post/2019/12/27/aspnet-core-automatic-ef-core-migrations-to-sql-database-on-startup
