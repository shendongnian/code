    const string MyDateFormat = "{0:yyyy-MM-dd}";
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = MyDateFormat, ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
