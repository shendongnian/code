    // define connection string and **PARAMETRIZED** insert query 
    string connectionStirng = ".....";
    string insertQry = "INSERT INTO tem (Telephone, Status, CreateDate) VALUES (@Telephone, @Status, @CreateDate);";
    
    // set up connection and command in using blocks
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(insertQry, conn))
    {
        // define the parameters
        cmd.Parameters.Add("@Telephone", SqlDbType.VarChar, 50).Value = telephone;
        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = status;
        cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DateTime.Now;
        
        // open connection, execute query, close connection
        conn.Open();
        int rowsInserted = cmd.ExecuteNonQuery();
        conn.Close();
    }
