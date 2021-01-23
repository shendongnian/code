    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
    
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Mary" },
            new Employee() { Id = 2, Name = "John" },
            new Employee() { Id = 3, Name = "Sam" },
        };
        }
    
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
