    public partial class MyFancyMigration : DbMigration
    {
        public override void Up()
        {
            SqlFile("myUpSQLFile.sql");
        }
        
        public override void Down()
        {
            SqlFile("myDownSQLFile.sql");
        }
    }
