    // define connection string and query to execute
    string connectionString = "server=.;database=YourDB;Integrated Security=SSPI;";
    string query = "Select SUM(IncCost) FROM Incomings WHERE CONVERT(DATETIME, IncDate, 103) <= GETDATE();";
    
    // set up connection to database and query command object
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(query, conn))
    {
        // open connection, execute command, close connection
        conn.Open();
        
        // you can use ExecuteScalar, since your query returns only a single value
        int sumOfIncCost = (int)cmd.ExecuteScalar();
        
        conn.Close();
        
        // set label text
        totalInc.Text = sumOfIncCost.ToString();
    }
    
    
