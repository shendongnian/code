    // Build your connection
    using(var con = new SqlConnection("your-connection-string"))
    {
         // Build your query
         var query = "SELECT TOP 1 ID FROM users WHERE username = @username AND password = @password";
         // Build a command to execute your query
         using(var cmd = new SqlCommand(con,query))
         {
              // Open your connection
              con.Open();
              // Add your parameters
              cmd.Parameters.AddWithValue("@username", txtUsername.Text);
              cmd.Parameters.AddWithValue("@password", txtPassword.Text);
              // Get your ID
              var sqlid = Convert.ToInt32(cmd.ExecuteScalar());
              // Do something here
         }
    }
    
  
        
