    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal TotalPrice { get; set; }
    
	[DisplayFormat(DataFormatString = "{0:C2}")]
	public readonly decimal TotalRoundedPrice
    {
		get ()
        {return Math.Round(this.TotalPrice);}
	}
