    public partial class RestaurantTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantGuest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RestaurantGuest", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "GuestId", "dbo.RestaurantGuest");
            DropIndex("dbo.Visits", new[] { "GuestId" });
            DropTable("dbo.Visits");
            DropTable("dbo.RestaurantGuest");
        }
    }
