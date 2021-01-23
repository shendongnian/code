    CreateTable(
        "dbo.Logins",
        c => new
            {
                LoginId = c.Int(nullable: false, identity: true),
                UserName = c.String(),
            })
        .PrimaryKey(t => t.LoginId);
                
    CreateTable(
        "dbo.UserProfiles",
        c => new
            {
                LoginId = c.Int(nullable: false),
            })
        .PrimaryKey(t => t.LoginId)
        .ForeignKey("dbo.Logins", t => t.LoginId)
        .Index(t => t.LoginId);
