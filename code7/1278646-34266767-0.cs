    public class Employee
    {
        public string empName { get; set; }
        public string VisitDate { get; set; }
        public string VisitTime { get; set; }
        public DateTime VisitInfo
        {
            get { //Do your stuff here }
            set { //Do your stuff here }
        }
    }
    
    public class EmployeeInfo
    {
        ObservableCollection<Employee> EmployeeList = new ObservableCollection<Employee>();
        public EmployeeInfo()
        {
            EmployeeList.Add(new Employee { empName = "John", VisitDate = "11/28/2015", VisitTime = "05:12 PM" });
            EmployeeList.Add(new Employee { empName = "Potter", VisitDate = "10/28/2015", VisitTime = "04:33 PM" });
            EmployeeList.Add(new Employee { empName = "James", VisitDate = "11/27/2015", VisitTime = "09:12 AM" });
        }
    }
