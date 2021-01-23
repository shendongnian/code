    using System.ComponentModel.DataAnnotations; /*put above namespace*/
    [Display(Name = "Start Date:")]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public System.DateTime StartDate { get; set; }
    [Display(Name = "End Date:")]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public System.DateTime EndDate { get; set; }
