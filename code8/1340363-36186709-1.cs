    using System.ComponentModel.DataAnnotations; /*put above namespace*/
    [Display(Name = "Start Date:")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public System.DateTime StartDate { get; set; }
    [Display(Name = "End Date:")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public System.DateTime EndDate { get; set; }
