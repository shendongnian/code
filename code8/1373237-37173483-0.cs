    public class EmployeeEditViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Review Date")]
        [Required]
        public DateTime? ReviewDate { get; set; }
        public EmployeeModel Employee { get; set; }
    }
