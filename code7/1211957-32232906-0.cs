    //Basic command and connection initialization 
    MySqlConnection conn = new MySqlConnection(ConnectString);
    MySqlCommand cmd = new MySqlCommand("GetCourses", conn);
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    
    // Add parameters
    cmd.Parameters.Add(new MySqlParameter("?UG", MySqlDbType.VarChar));
    cmd.Parameters["?UG"].Direction = ParameterDirection.Output;
    
    cmd.Parameters.Add(new MySqlParameter("?PG", MySqlDbType.VarChar));
    cmd.Parameters["?PG"].Direction = ParameterDirection.Output;
    
    // Open connection and Execute 
    conn.Open();
    cmd.ExecuteNonQuery();
    // Get values from the output params
    string PG = (string)cmd.Parameters["?PG"].Value;
    string UG = (string)cmd.Parameters["?UG"].Value;
