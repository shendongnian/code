    public override void Up()
    {
        DropIndex("dbo.PinnacleAccount", new[] { "User_Id" });
        RenameColumn(table: "dbo.PinnacleAccount", name: "User_Id", newName: "UserId");
        DropPrimaryKey("dbo.PinnacleAccount");
        AlterColumn("dbo.PinnacleAccount", "UserId", c => c.String(nullable: false, maxLength: 128));
        AddPrimaryKey("dbo.PinnacleAccount", "UserId");
        CreateIndex("dbo.PinnacleAccount", "UserId");
        DropColumn("dbo.PinnacleAccount", "Id");
        DropColumn("dbo.PinnacleAccount", "UserIdOld");
    }
    
    public override void Down()
    {
        AddColumn("dbo.PinnacleAccount", "UserIdOld", c => c.String(nullable: false));
        AddColumn("dbo.PinnacleAccount", "Id", c => c.Guid(nullable: false, identity: true));
        DropIndex("dbo.PinnacleAccount", new[] { "UserId" });
        DropPrimaryKey("dbo.PinnacleAccount");
        AlterColumn("dbo.PinnacleAccount", "UserId", c => c.String(maxLength: 128));
        AddPrimaryKey("dbo.PinnacleAccount", "Id");
        RenameColumn(table: "dbo.PinnacleAccount", name: "UserId", newName: "User_Id");
        CreateIndex("dbo.PinnacleAccount", "User_Id");
    }
