      var connectionString = "...";
      var sqlQuery = "...";
    
      // Sample using SqlCommand
      try
      {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
          sqlConnection.Open();
          using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
          {
            sqlCommand.ExecuteNonQuery();
          }
        }
        MessageBox.Show("OK");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error : " + ex);
      }
    
      // Sample using SqlDataAdapter
      try
      {
        var dataTable = new DataTable();
        using (var sqlConnection = new SqlConnection(connectionString))
        {
          sqlConnection.Open();
          using (var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection))
          {
            sqlDataAdapter.Fill(dataTable);
          }
        }
        MessageBox.Show("OK");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error : " + ex);
      }
