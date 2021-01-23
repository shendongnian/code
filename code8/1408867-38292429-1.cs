     public override void Up()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Emails = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserLogins", t => t.Emails, cascadeDelete: true)
                .Index(t => t.Emails, unique: true);
            
        }
