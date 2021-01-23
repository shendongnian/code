    [DisplayName("Start Date")]
    [DataType(DataType.Date)] // if HTML5 is used you can apply this attribute
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime StartDateTime { get; set; }
    
    [DisplayName("End Date")]
    [DataType(DataType.Date)] // if HTML5 is used you can apply this attribute
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime EndDateTime { get; set; }
