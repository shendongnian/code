    ...
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Settings = c.String(),
                    })
                .PrimaryKey(t => t.ID);
    ...
