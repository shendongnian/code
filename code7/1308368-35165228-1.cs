       using (SqlConnection con = new SqlConnection(myconnectioninfo))
    	{
    	    con.Open();
    	    using (SqlCommand command = new SqlCommand("SELECT TOP 1 [TotalIncidents] FROM sixMonthReport ORDER BY [TotalIncidents] DESC", con))
    	   {
            Object temp = cmd.ExecuteScalar();
           }
    	}
        label.Content = temp.ToString();
