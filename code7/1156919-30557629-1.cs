    [Key] 
    [Column(Order=1)] 
    [ForeignKey("Order")]
    public int OrderID { get; set; }
    [Key] 
    [Column(Order=2)] 
    [ForeignKey("Item")]
    public int ItemID { get; set; }
