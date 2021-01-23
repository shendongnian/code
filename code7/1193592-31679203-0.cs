    public partial class addedimportantcasetable : DbMigration
        {
            public override void Up()
            {
                CreateTable(
                    "dbo.ImportantCases",
                    c => new
                        {
                            ImportantId = c.String(nullable: false, maxLength: 128),
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
