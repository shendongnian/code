    public class MyDataInitializer
    {
        public async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<MyCustomDB>();
            var databaseCreated = await db.Database.EnsureCreatedAsync();
            if (databaseCreated)
            {
                await GenerateData(db);
            }
        }
        private static async Task GenerateData(MyCustomDB context)
        {
            context.Users.Add(new User
            {
                Name = "admin",
                PasswordParam = "pwd",
            });
            await context.SaveChangesAsync();
            // or execute custom sql here
        }
    }
