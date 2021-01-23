    public class EmployeeViewModel 
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }
        public decimal PersonelSalary {get;set;}
    }
