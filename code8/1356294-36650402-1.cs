    // Open your connection
    using(var connection = new SqlConnection("{your connection string}"))
    {
         // Build your query
         var query = "SELECT TOP 1 userid FROM register WHERE username = @username AND password = @password";
         // Build a command (to execute your query)
         using(var command = new SqlCommand(query, connection))
         {
              // Open your connection
              connection.Open();
              // Add your parameters
              command.Parameters.AddWithValue("@username",UserName.Text);
              command.Parameters.AddWithValue("@password",Password.Text);
              // Execute your query
              var user = Convert.ToString(command.ExecuteScalar());
              // If a user was found, then set it
              if(!String.IsNullOrEmpty(user))
              {
                   Session["checkuserid"] = user;
              }
              else
              {
                   // No user was found, consider alerting the user
              }
         }
    }
