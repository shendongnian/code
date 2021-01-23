    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal TotalPrice { 
        get ()
        {return Math.Round(_TotalPrice,0)}
        set; }
