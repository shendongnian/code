     using (var scope = app.ApplicationServices.CreateScope())
     {
         var dbContext = scope.ServiceProvider.GetService<T>();
         dbContext.Database.Migrate();
     }
