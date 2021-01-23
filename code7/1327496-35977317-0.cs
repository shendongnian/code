    var client = new SqlClient();
    var allEmployeeData = EmployeeBal.GetAllEmployees(client, query);
    class EmployeeBal
    {
        public static Employee GetAllEmployees(ISqlClient client)
        {
            return client.Execute("Select * from Employee");
        }
    }
