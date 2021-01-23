    public class TimeSheetsViewModel
    {
        public ObservableCollection<Time> Times { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<string> JobCodes { get; set; }
        public TimeSheetsViewModel()
        {
            Times = new ObservableCollection<Time>();
            Departments = new ObservableCollection<Department>();
            GetDepartments();
            JobCodes = new ObservableCollection<string>();
            GetJobCodes();
        }
        private void GetJobCodes()
        {
            JobCodes = new ObservableCollection<string> { "01-A", "01-B", "02-A", "02-B", "03-A", "03-B" };
        }
        private void GetDepartments()
        {
            Departments = new ObservableCollection<Department> {
                new Department("01"),
                new Department("02"),
                new Department("03")
            };
        }
    }
    public class Department
    {
        public String DepartmentCode { get; set; }
        public Department(string departmentCode) { DepartmentCode = departmentCode; }
    }
    public class Time
    {
        //time in etc etc
        public Department Department { get; set; }
        public string Job { get; set; }
    }
