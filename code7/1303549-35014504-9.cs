    CreateTable(
        "dbo.Users",
        c => new
            {
                UserId = c.Long(nullable: false, identity: true),
                UserName = c.String(),
            })
        .PrimaryKey(t => t.UserId);
    
    CreateTable(
        "dbo.BackendUser",
        c => new
            {
                UserId = c.Long(nullable: false),
                IsSystemOwner = c.Boolean(nullable: false),
            })
        .PrimaryKey(t => t.UserId)
        .ForeignKey("dbo.Users", t => t.UserId)
        .Index(t => t.UserId);
    
    CreateTable(
        "dbo.ResellerContact",
        c => new
            {
                UserId = c.Long(nullable: false),
                ResellerName = c.String(),
            })
        .PrimaryKey(t => t.UserId)
        .ForeignKey("dbo.BackendUser", t => t.UserId)
        .Index(t => t.UserId);
