    [DataType(DataType.Upload)]
    [Display(Name = "Upload File")]
    [Required(ErrorMessage = "Please choose file to upload")]
    [NotMapped]
    public HttpPostedFileBase File { get; set; }
    
    public string FileName { get; set; }
