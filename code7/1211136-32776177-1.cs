    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class EmployeeService : IEmployeeService
    {
        #region Methods
        /// <summary>
        /// Add the New EmployeeRecord Methods
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public string AddEmployeeDetails(Employee Employee)
        
        
        {
            string result = string.Empty;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                con = new SqlConnection(ConString);
                con.Open();
                cmd = new SqlCommand("usp_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", Employee.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", Employee.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", Employee.EmployeeAddress);
                cmd.Parameters.AddWithValue("@EmployeePhoneNo", Employee.EmployeePhoneNo);
                cmd.Parameters.AddWithValue("@Action", Employee.Action);
                cmd.ExecuteNonQuery();
                con.Close();
                result = "Record Inserted Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// Update EmployeeRecords Methods
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public string UpdateEmployeeDetails(Employee Employee)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds;
            ds = new DataSet();
            string result = string.Empty;
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            try
            {
                con = new SqlConnection(ConString);
                cmd = new SqlCommand("usp_Employee", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("EmployeeID", Employee.EmployeeID);
                cmd.Parameters.AddWithValue("EmployeeName", Employee.EmployeeName);
                cmd.Parameters.AddWithValue("EmployeeAddress", Employee.EmployeeAddress);
                cmd.Parameters.AddWithValue("EmployeePhoneNo", Employee.EmployeePhoneNo);
                cmd.Parameters.AddWithValue("@Action", Employee.Action);
                cmd.ExecuteNonQuery();
                result = "Record Updated Sucessfully";
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// GetEmployeeDetails Methods
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployeeDetails(int PageNumber, int PageSize, string SortColumn, string SortOrder)
        {
            List<Employee> Employees = null;
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds;
            SqlDataAdapter sda;
            ds = new DataSet();
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            try
            {
                con = new SqlConnection(ConString);
                con.Open();
                cmd = new SqlCommand("usp_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GET");
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@PageSize", PageSize);
                cmd.Parameters.AddWithValue("@SortColumn", SortColumn);
                cmd.Parameters.AddWithValue("@SortOrder", SortOrder);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();
                Employees = parseEmployeeDetails(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Employees;
        }
        /// <summary>
        ///Parsing the EmployeeRecords
        /// </summary>
        /// <param name="dsEmployeeDetails"></param>
        /// <returns></returns>
        public List<Employee> parseEmployeeDetails(DataSet dsEmployeeDetails)
        {
            List<Employee> employees = null;
            try
            {
                employees = new List<Employee>();
                if (dsEmployeeDetails != null && dsEmployeeDetails.Tables.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dsEmployeeDetails.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = Convert.ToString(dr["EmployeeID"]);
                        employee.EmployeeName = Convert.ToString(dr["EmployeeName"]);
                        employee.EmployeeAddress = Convert.ToString(dr["EmployeeAddress"]);
                        employee.EmployeePhoneNo = Convert.ToString(dr["EmployeePhoneNo"]);
                        employee.TotalCount = Convert.ToInt32(dr["TotalCount"]);
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employees;
        }
        #endregion
    }
}
