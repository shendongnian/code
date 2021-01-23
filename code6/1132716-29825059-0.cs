    public class EmployeeViewModel
    {         
        [StringLength(20, ErrorMessage = "{0} cannot be longer than {1} characters.")] 
        public string Name{ get; set; }
    }
