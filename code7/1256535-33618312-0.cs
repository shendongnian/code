    namespace Core.Controllers
    {
    ...
      public void Configuration(IAppBuilder app)
      {
        app.UseHangfire(config =>
        {
            config.UseSqlServerStorage(ConnectionString.GetTVConnectionString());
            config.UseServer();
        });
      }
    ...
    }
