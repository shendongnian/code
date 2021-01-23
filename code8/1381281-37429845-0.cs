    public partial class SomeName: DbMigration
        {
            public override void Up()
            {
                Sql(@"Add Command For StoredProcedure");
                
            }
            
            public override void Down()
            {
                Sql(@"Drop Command for Stored Procedure")
            }
        } 
