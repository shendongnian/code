    string query = "SELECT * FROM reports WHERE ID=@rowid";        
    using (SqlConnection myConnection = new SqlConnection(connectionString))
    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
    {
    	myCommand.Parameters.AddWithValue("@rowid", row);    
    	myConnection.Open();    
    	using (SqlDataReader rdr = myCommand.ExecuteReader())
    	{
    		while (rdr.Read())
    		{
    			string myname = rdr["itemname"].ToString();    
    			itemnametext.Text = myname;
    		}
    	}
    }
