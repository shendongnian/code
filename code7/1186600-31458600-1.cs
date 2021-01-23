    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal TotalPrice { 
        get ()
        {return Math.Round(this.TotalPrice);}
        set;
