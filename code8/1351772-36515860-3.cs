    public class OrderVM
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeVM> Employees { get; set; }
    }
    public class EmployeeVM
    {
        public string Name { get; set; }
        public int Hours { get; set; }
    }
