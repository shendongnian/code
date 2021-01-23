    CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        ProjectTaskId = c.Int(nullable: false, identity: true),
                        SomeString = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectTaskId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        SomeString = c.String(),
                        ProjectET_ProjectTaskId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.ProjectTasks", t => t.ProjectET_ProjectTaskId)
                .Index(t => t.ProjectET_ProjectTaskId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ProjectId);
