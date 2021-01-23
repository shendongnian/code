    public class Employee
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string someMoreDataThatShouldNotBeSerialized { get; set; }
    }
    public class EmployeeContainer
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
