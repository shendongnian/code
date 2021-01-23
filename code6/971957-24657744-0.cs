    using (SqlConnection conn = new SqlConnection("connectionString")) 
    using (SqlCommand cmd = new SqlCommand()) 
    { 
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = @"INSERT INTO Materiel VALUES (@textParam, @intParam, @dateParam, ...)";  
        // add parameters
        cmd.Parameters.AddWithValue("@textParam", "blah blah");  
        cmd.Parameters.AddWithValue("@intParam", 12345);  
        cmd.Parameters.AddWithValue("@dateParam", DateTime.UtcNow);  
        ...
    
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery(); 
        }
        catch(SqlException e)
        {
            // do something with exception
        }
    }
