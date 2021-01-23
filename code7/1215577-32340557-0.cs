    public class EmployeeVM
    {
        public EmployeeVM()
        {
            Departments = new List<DepartmentSelect>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public List<DepartmentSelect> Departments { get; set; }
        public static Func<Employee, EmployeeVM> FromEntity = item => new EmployeeVM() { 
            Id = item.Id,
            FirstName = item.FirstName,
            LastName = item.LastName,
            Dob = item.Dob
        };
    }
    
    // get single EmployeeVM
    var eVm = EmployeeVM.FromEntity(context.Employees.Find(id));
    // get List<EmployeeVM
    var eVmList = context.Employees.Select(EmployeeVM.FromEntity).ToList();
