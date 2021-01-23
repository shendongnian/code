        public partial class MigrationFile : DbMigration
        {
          public override void Up()
          {
           // Add or update the data
           Sql("UPDATE ...");
           Sql("INSERT ...");
          }
            
          public override void Down()
          {
           // Remove Data
          }
        }
