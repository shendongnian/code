    public class EmployeeStaffViewModel
    {
        public EmployeeStaffViewModel()
        {
            Staff = new List<StaffModel>();
            Employee = new List<EmployeeModel>();
        }
        public List<StaffModel> Staff { get; set; }
        public List<EmployeeModel> Employee { get; set; }
    }
