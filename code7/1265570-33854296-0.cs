    public class EmployeeList
    {
        public ObservableCollection<Employee> List { get; set; } = new ObservableCollection<Employee>();
    }
    
    public class Employee
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Employee(string name, string surName)
        {
            this.Name = name;
            this.SurName = surName;
        }
    }
