    private void Count()
    {
    	string selectedcmd = "SELECT COUNT(Review_rate) AS Review_count FROM Review WHERE (Paper_id = '" + Session["PaperID"] + "')";
    	using(SqlConnection conn = new SqlConnection(connectionString) )
    	using(SqlCommand command = new SqlCommand(selectedcmd, conn))
    	{
            conn.Open();
    		var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
            	//more code
    
            	average(conn)
            }
    	}
    }
    private void average(SqlConnection conn)
    {
    	//use the connection passed as an argument
    }
