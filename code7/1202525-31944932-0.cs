    [Required]
    [Display(ResourceType = typeof(Resources.Data), Name = "FerretBirthDay")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
