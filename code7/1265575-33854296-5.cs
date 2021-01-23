    public class View
    {
        public EmployeeList EmployeeList { get; set; }
    
        public View()
        {
            EmployeeList = new EmployeeList() { List = { new Employee("Alex", "Z"), new Employee("Alex", "K") } };
        }
    }
