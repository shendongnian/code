    [WebMethod]
        public static string GetEmployees(int pageNumber, int pageSize)
        {
            List<Employee> listEmployees = new List<Employee>();
    
            string cs =  ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@PageNumber",
                    Value = pageNumber
                });
    
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@PageSize",
                    Value = pageSize
                });
    
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    listEmployees.Add(employee);
                }
            }
    
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listEmployees);
        }
    }
