    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(ApplicationDbContext context)
        {
            ParameterSeeder.Seed(context);
            RoleSeeder.Seed(context);
            UserSeeder.Seed(context);
        }
    }
