    public partial class SetImportantIdasIdentitySpecification : DbMigration
        {
            public override void Up()
            {
                CreateTable(
                   "dbo.ImportantCases",
                   c => new
                   {
                       ImportantId = c.Int(nullable: false, identity: true),
                       EvpId = c.Int(nullable: false),
                       Comment = c.String(),
                       CategoryId = c.Int(nullable: false),
                   })
                   .PrimaryKey(t => t.ImportantId);
            }
            
            public override void Down()
            {
                DropTable("dbo.ImportantCases");
            }
        }
