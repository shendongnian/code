    public class YourModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is mandatory")]
        [RestrictedDate]
        public DateTime created_date { get; set; } 
    }
