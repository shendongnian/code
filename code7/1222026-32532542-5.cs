    public class Employee
    {
        public Employee()
        {
            this.Departments = new List<Department>();
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }
    }
    public class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
