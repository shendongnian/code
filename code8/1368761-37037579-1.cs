    using(var connection = new SqlConnection(dbConnection))
         using(var command = new SqlCommand(query, connection))
         {
              connection.Open();
              command.Parameters.AddWithValue("@TeamId", 1);
              command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = "Example";
              command.ExecuteNonQuery();
         }
