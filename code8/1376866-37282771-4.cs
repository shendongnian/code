    // Define a parameter in your query using the @parameter format (or ? in OleDbConnections)
    var sql ="SELECT * FROM Users WHERE Username = @username";
    using(var command = new SqlCommand(connection, sql))
    {
         // Ensure your connection is open and other code here...
         // Add your parameter
         command.Parameters.AddWithValue("@username",txtUsername.Text);
         // Any other logic here...
         // Execute your query
         using(var reader = command.ExecuteReader())
         {
              // Do your thing...
         }
    }
