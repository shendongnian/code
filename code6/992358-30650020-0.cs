    [Display(Name = "TdPrime", ResourceType = typeof(Resources.Somethings.Something))]       
    [RegularExpression(@"-?(?:\d*[\,\.])?\d+", 
                    ErrorMessageResourceName = "DataType_Number", 
                    ErrorMessageResourceType = typeof(Validations))]       
    [Range(0, 999.9999, 
              ErrorMessageResourceName = "RangeAttribute_ValidationError",
              ErrorMessageResourceType = typeof(Validations))]
    [DisplayFormat(DataFormatString = "{0:#.####}", ApplyFormatInEditMode = true)]
    public decimal? TdPrime { get; set; }
