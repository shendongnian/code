    var message = String.Empty;
    using(var connection = new SqlConnection(dbConnection))
         using(var command = new SqlCommand(query, dbConnection))
         {
              connection.Open();
              command.CommandType =  CommandType.Text;
              command.Parameters.Add("@Column", SqlDbType.NVarChar).Value = message;
              command.ExecuteNonQuery();
         }
