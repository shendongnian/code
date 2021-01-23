    // in Startup.cs
    services.AddEntityFramework()
      .AddSqlite()
      .AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlite("Filename=./test.db"));
    // in a constructor argument
    public HomeController(ApplicationDbContext context)
    ...
    // in code
    using(var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
    ....
