    public class MyDbConfiguration: DbMigrationsConfiguration<MyDbContext>
      {
        public MyDbConfiguration()
        {
          this.AutomaticMigrationsEnabled = true;
          this.AutomaticMigrationDataLossAllowed = true;
        }
      }
