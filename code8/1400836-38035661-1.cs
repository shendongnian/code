    public static void Seed(IApplicationBuilder app)
    {
        // Get an instance of the DbContext from the DI container
        using (var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
        {
            // perform database delete
            context.Database.EnsureDeleted;
            //... perform other seed operations
        }
    }
