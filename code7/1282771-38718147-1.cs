    public override void Up()
    {
        DropForeignKey("dbo.PinnacleAccount", "UserId", "dbo.AspNetUsers");
        DropIndex("dbo.PinnacleAccount", new[] { "UserId" });
        RenameColumn(table: "dbo.PinnacleAccount", name: "UserId", newName: "User_Id");
        AddColumn("dbo.PinnacleAccount", "UserIdOld", c => c.String(nullable: false));
        AlterColumn("dbo.PinnacleAccount", "User_Id", c => c.String(maxLength: 128));
        CreateIndex("dbo.PinnacleAccount", "User_Id");
        AddForeignKey("dbo.PinnacleAccount", "User_Id", "dbo.AspNetUsers", "Id");
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.PinnacleAccount", "User_Id", "dbo.AspNetUsers");
        DropIndex("dbo.PinnacleAccount", new[] { "User_Id" });
        AlterColumn("dbo.PinnacleAccount", "User_Id", c => c.String(nullable: false, maxLength: 128));
        DropColumn("dbo.PinnacleAccount", "UserIdOld");
        RenameColumn(table: "dbo.PinnacleAccount", name: "User_Id", newName: "UserId");
        CreateIndex("dbo.PinnacleAccount", "UserId");
        AddForeignKey("dbo.PinnacleAccount", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
    }
