    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        using (SqlCommand command = new SqlCommand("SELECT TOP 2 * FROM Dogs1", con))
        using (SqlDataReader reader = command.ExecuteReader())
        {
    	    while (reader.Read())
    	    {
                //Use reader.GetInt32, reader.GetString, etc 
                //depending on the type of data in the table
    	        Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
    	    }
        }
    }
