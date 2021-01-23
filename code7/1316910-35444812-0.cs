    public int BookingID { get; set; }
    public int CustomerID { get; set; }
    [ForeignKey("Origin")]
    public int OriginID { get; set; }
    [ForeignKey("Destination")]
    public int DestinationID { get; set; }
    
    public string Awb { get; set; }
    public string ClientRef { get; set; }
    public string Info { get; set; }
    
    // Navigation
    public virtual Airport Origin { get; set; }
    public virtual Airport Destination { get; set; }
    public virtual Customer Customer { get; set; }
