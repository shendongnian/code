    public class EmployeeInfo
    {
        public string EmployeeName {get;set;}
        // other properties
        public EmployeeInfo(Employee emp, Store store, Address address)
        {
            EmployeeName = emp.EmpName;
            // assign other properties
        }
    }
