    services.AddDbContext<MyDbContext>(options => ...);
    var options = services.BuildServiceProvider()
                          .GetRequiredService<DbContextOptions<MyDbContext>>();
    Task.Run(() =>
    {
        using(var dbContext = new MyDbContext(options))
        {
            var model = dbContext.Model; //force the model creation
        }
    });
