    public void ConfigureServices(IServiceCollection services)
     {
      services
        .AddEntityFramework()
        .AddSqlServer()
        .AddDbContext<ProjectContext>(options =>
        {
            var connString =
                Configuration.Get("Data:timesheet_db:ConnectionString");
            options.UseSqlServer(connString);
        });
      }
