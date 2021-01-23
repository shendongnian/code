    [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedUtc { get; set; 
  
      "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedUtc = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.ProductId);
