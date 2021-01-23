    CreateTable(
        "dbo.UserProfiles",
        c => new
            {
                UserProfileId = c.Int(nullable: false, identity: true),
            })
        .PrimaryKey(t => t.UserProfileId);
                
    CreateTable(
        "dbo.Logins",
        c => new
            {
                UserProfileId = c.Int(nullable: false),
                UserName = c.String(),
            })
        .PrimaryKey(t => t.UserProfileId)
        .ForeignKey("dbo.UserProfiles", t => t.UserProfileId)
        .Index(t => t.UserProfileId);
