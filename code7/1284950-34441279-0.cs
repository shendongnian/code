    public partial class Employee {
        public class EmployeeMD {
            [Display(Name = "Last Name", Order = -9, 
            Prompt = "Enter Last Name", Description="Emp Last Name")]
            public object LastName { get; set; }
    
            [Display(Name = "Manager", AutoGenerateFilter=false)]
            public object Employee1 { get; set; }
        }
    }
