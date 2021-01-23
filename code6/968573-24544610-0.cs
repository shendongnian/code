            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        PrimaryGroupId = c.Guid(),
                        Group_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey( "dbo.Groups", t => t.Group_Id)
                .ForeignKey( "dbo.Groups", t => t.PrimaryGroupId)
                .Index(t => t.PrimaryGroupId)
                .Index(t => t.Group_Id);
