    public class EmployeeRow
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Employee ToEmployee()
        {
            return new Employee(Name, Age);
        }
    }
