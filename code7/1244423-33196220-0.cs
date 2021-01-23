    [Required]
    [DataType(DataType.Date)]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CarManufactureDate { get; set; }
