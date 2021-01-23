    using(var sqlConnection = new SqlConnection("Your Connection String"))
    {
          var query = "Your Query";
          using(var sqlCommand = new SqlCommand(query,sqlConnection))
          {
                sqlConnection.Open();
                // Execute your query here using sqlCommand.ExecuteNonQuery()
                // or some other execution method
          }
    }
