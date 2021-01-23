    string cs = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;
    using (SqlConnection con = new SqlConnection(cs))
    {
         string inClause = string.Join(",", userIDList);
         SqlCommand cmd = new SqlCommand(@"SELECT FirstName, LastName 
               FROM Employee WHERE EmployeeId NOT IN(" + inClause + ")", con);
         con.Open();
         GridView4.DataSource = cmd.ExecuteReader();
         GridView4.DataBind();
    }
