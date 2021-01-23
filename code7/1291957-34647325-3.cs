    public DataSet Execute(Statement stat)
    {
    		DataSet ds = new DataSet();
    		
    		SqlConnectionStringBuilder dbConString = new SqlConnectionStringBuilder();
    		dbConString.UserID = "My Username";
    		dbConString.Password = "My Password";
    		dbConString.DataSource = "My Server Address";
    		
    		using (SqlConnection con = new SqlConnection(dbConString.ConnectionString))
    		{
    			con.Open();
    			SqlCommand cmd = new SqlCommand("SELECT * FROM MyTable", con);
    
    			var adapter = new SqlDataAdapter(cmd);
    			adapter.Fill(ds);
    			
    		}
    		return ds;
    }
