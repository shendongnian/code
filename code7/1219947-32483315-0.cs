    [Display(Name = "Event Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    [Range(typeof(DateTime), "01-01-2010", "12-31-2030")]
    public DateTime? EventDate { get; set; }
