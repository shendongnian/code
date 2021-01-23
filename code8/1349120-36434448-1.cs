	public class UserContext
    {
		private ConnectionString = ""
		
		// 1st constructor you pass in connection string.
		public UserContext(string connectionString)
		{
			ConnectionString = connectionString;
		}
		
        // 2nd constructor you use the one in the web.config file.
		public UserContext()
		{
			ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
		}
		
		public int GetUserID(string userName, string password)
		{
			// declare the result variable.
			MyUser result
			
			using(var con = new SqlConnection(ConnectionString))
			{
				
				var query = "SELECT TOP 1 ID FROM users WHERE username = @username AND password = @password";
				// Build a command to execute your query
				 using(var cmd = new SqlCommand(con,query))
				 {
					  // Open connection
					  con.Open();
					  // Add your parameters
					  cmd.Parameters.AddWithValue(userName);
					  cmd.Parameters.AddWithValue(password);
					  // Get ID
					  var sqlid = Convert.ToInt32(cmd.ExecuteScalar());
					  result = new MyUser(sqlid, userName);
					  
				 }
			}
			return result;
		}
    }
