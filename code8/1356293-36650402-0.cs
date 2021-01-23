    using(var connection = new SqlConnection("{your connection string}"))
    {
         var query = "SELECT TOP 1 userid FROM register WHERE username = @username AND password = @password";
         using(var command = new SqlCommand(query, connection))
         {
              connection.Open();
              command.Parameters.AddWithValue("@username",UserName.Text);
              command.Parameters.AddWithValue("@password",Password.Text);
               
              var user = Convert.ToString(command.ExecuteScalar());
              Session["checkuserid"] = user;
         }
    }
