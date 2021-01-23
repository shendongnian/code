        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        TripID = c.Int(nullable: false),
                        Text = c.String(),
                        TableID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Trips", t => t.TripID, cascadeDelete: true)
                .Index(t => t.TripID);
            
