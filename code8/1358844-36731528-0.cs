    public static Boolean PerformDatabaseAction(string sqlQuery) 
    {
        using (SqlConnection con = DbConnect()) // Get SqlConnection
        {
            SqlCommand cmd = new SqlCommand(sqlQuery); 
            cmd = new SqlCommand(sqlQuery); 
            CommandType = System.Data.CommandType.Text; 
            Connection = con; 
            int rows = cmd.ExecuteNonQuery(); // Gets the count of affected rows
            if(rows > 0)
                return true;
            else 
                return false;
        }
    }
