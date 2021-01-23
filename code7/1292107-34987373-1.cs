        public override void Up()
        {
            CreateTable(
                "BugReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID)                ;
            
            CreateTable(
                "DublicateBugReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID)                ;
            
            CreateTable(
                "DublicateBugReportBugReports",
                c => new
                    {
                        DublicateBugReport_ID = c.Int(nullable: false),
                        BugReport_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DublicateBugReport_ID, t.BugReport_ID })                
                //pay attention! - cascadeDelete: true
                .ForeignKey("DublicateBugReports", t => t.DublicateBugReport_ID, cascadeDelete: true)
                .ForeignKey("BugReports", t => t.BugReport_ID, cascadeDelete: true)
                .Index(t => t.DublicateBugReport_ID)
                .Index(t => t.BugReport_ID);
            
        }
