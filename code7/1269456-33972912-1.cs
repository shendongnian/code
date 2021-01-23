	// An int property to map to your database:
    [Column("Price")]
	public int PriceInt { get; set; }
	// Use this property from code.
	[NotMapped]   
	public decimal Price 
    {
		// Cast to decimal for decimal division.
		get	{ return (decimal)PriceInt / 100; }
		set { PriceInt = (int)(value * 100); }
	}
	
