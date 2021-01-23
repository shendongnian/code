    [DataType(DataType.Date), Required]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime StartTime { get; set; }
    [DataType(DataType.Date), Required]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime EndTime { get; set; }
