    public  string GetData()
        {
            DataTable dt = new DataTable();
            List<Employee> details = new List<Employee>();
    
           connection();
            com = new SqlCommand("select FirstName, LastName, Company from Employee", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employee user = new Employee();
                       // user.Id = Int32.Parse(string dr["Id"]);
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Company = dr["Company"].ToString();
                        details.Add(user);
    
    
                    }
                    return details;
    
                }
