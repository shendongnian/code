    void FillLogins(string userName, string password)
	    // Open connection
	    using (SqlConnection c = new SqlConnection(yourConnectionString))
	    {
		c.Open();
		// Create new DataAdapter / Command
		using (SqlDataAdapter a = new SqlDataAdapter(
		    "Select Count (*) From dbo.[LOGIN] where Username= @userName AND Password = @password", c))
		  {
            a.SelectCommand.Parameters.AddWithValue("@userName", userName);
            a.SelectCommand.Parameters.AddWithValue("@password", password);
		    // Use DataAdapter to fill DataTable
		    DataTable t = new DataTable();
		    a.Fill(t);
		  }
	   }
    }
