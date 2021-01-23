    public void Execute()
    {
    	SqlConnectionStringBuilder dbConString = new SqlConnectionStringBuilder();
    	dbConString.UserID = "My Username";
    	dbConString.Password = "My Password";
    	dbConString.DataSource = "My Server Address";
    	
    	using (SqlConnection con = new SqlConnection(returnConnectionString().ConnectionString))
    	{
    		con.Open();
    		for (int i = 0; i < commands.Count; i++)
    		{
    			SqlCommand cmd = new SqlCommand("UPDATE MyTable SET Name = 'New Name' WHERE ID = 1");
    			cmd.Connection = con;
    			cmd.ExecuteNonQuery();
    		}
    	}
