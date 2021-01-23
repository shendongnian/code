        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture_Type = c.String(),
                        Picture_Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture_Type = c.String(),
                        Picture_Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
