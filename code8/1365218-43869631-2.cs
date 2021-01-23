        using (SqlConnection connection = new SqlConnection(@"data source="SERVER NAME";integrated security=false;uid="USER";password="PASSWORD";"))
        {
    conn.Open();
    // 1.  create a command object identifying the stored procedure
    SqlCommand cmd  = new SqlCommand("SearchAllDatabases", conn);
    // 2. set the command object so it knows to execute a stored procedure
    cmd.CommandType = CommandType.StoredProcedure;
    // 3. add parameter to command, which will be passed to the stored procedure
    cmd.Parameters.Add(new SqlParameter("@SearchTerm", value));
    cmd.ExecuteNonQuery();
         
    }
