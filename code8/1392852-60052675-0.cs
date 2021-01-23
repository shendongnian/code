     public class DataContextAutomaticMigrationStartupFilter<T> : IStartupFilter
      where T : DbContext
    {
        /// <inheritdoc />
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<T>().Database.SetCommandTimeout(160);
                    scope.ServiceProvider.GetRequiredService<T>().Database.Migrate();
                }
                next(app);
            };
        }
    }
