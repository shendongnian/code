     [WebMethod]
        public EmployeesDetails GetDetails(RequestParams[] request)
        {
            
    
            // Query the database, request contains an array of  RequestParams
        }
    
    public class RequestParams
    {
        public int employeeID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Email { get; set; }
    }
    public class EmployeesDetails
    {
        public int PassportNumber { get; set; }
    }
