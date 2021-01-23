    private static string ConnectionString = "Data Source=MCDU11;Initial Catalog=VisitorManagement;Integrated Security=True";
    
    protected string GetLoggedUserId(string username, string password) {
    	var id = string.Empty;
    	using(var conn = new SqlConnection(ConnectionString) {
    		var cmd = new SqlCommand("SELECT * FROM SecurityUser WHERE Username = '" + username + "' AND "
                                            + "Password='" + password)  + "'" , conn);
    		conn.Open();
    		using(var reader = cmd.ExecuteReader()){
       			if(reader.Read()){
    				id = reader["Id"].ToString();
    			}	
    		}
    	} 
    	return id;
    }
    
    protected string UpdateLoggedUser(string username) {
    	using(var conn = new SqlConnection(ConnectionString) {
    		var cmd = new SqlCommand("update SecurityUser set LoginOn ='" + DateTime.Now + "' , " + "WHERE Username ='" + username + "'", conn);
    		conn.Open();
    		cmd.ExecuteNonQuery();
    	} 
    }
    
    protected void btnLogin_Click(object sender, EventArgs e) {
    
    	var loggedId = GetLoggedUserId(txtUsername.Text.Trim(),Encrypt(txtPassword.Text.Trim()));
    	
    	if(!string.IsNullOrWhiteSpace(loggedId))
    	{
    		UpdateLoggedUser(txtUsername.Text.Trim());
    		Response.Redirect("SecurityHome.aspx");
    	}
    	else
    	{
    		lblError.Text = "Either username and/or password is wrong. Please try again!";
    	}   
    }
