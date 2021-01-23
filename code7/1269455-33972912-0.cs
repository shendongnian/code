	// An int property to map to your database:
    [Column("Price")]
	public int PriceInt { get; set; }
    {
        get { return (int)(Price * 100); }
        set { Price = (decimal)value / 100; }
    }
	// Use this property from code.
	[NotMapped]   
	public decimal Price { get; set; }
