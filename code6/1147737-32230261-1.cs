    internal sealed class ApplicationConfiguration: DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Application";
        }
	}
	
    internal sealed class CompanyConfiguration : DbMigrationsConfiguration<CompanyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Company";
        }
	}
	
