       Object temp = null;
        using (SqlConnection con = new SqlConnection(myconnectioninfo))
        {
    	    con.Open();
    	   using (SqlCommand command = new SqlCommand("SELECT TOP 1 [TotalIncidents] FROM sixMonthReport ORDER BY [TotalIncidents] DESC", con))
    	   {
            temp = cmd.ExecuteScalar();
           }
    	}
        label.Content = temp?.ToString();
