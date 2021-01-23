     public partial class FirstDb : DbMigration
     {
         public override void Up()
         {
             CreateTable(
                 "dbo.Missions",
                 c => new
                     {
                         MissionId = c.Long(nullable: false, identity: true),
                         Amount = c.Int(nullable: false),
                         Amount2 = c.Int(nullable: false),
                         HeroId = c.Long(nullable: false),
                     })
                 .PrimaryKey(t => t.MissionId);
             
         }
         
         public override void Down()
         {
             DropTable("dbo.Missions");
         }
     }
