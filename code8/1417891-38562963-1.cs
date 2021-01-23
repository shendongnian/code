      var connectionString = "...";
      var sqlQuery = "...";
    
      // Sample using SqlCommand
      try
      {
        using (var conn = new SqlConnection(connectionString))
        {
          conn.Open();
          using (var cmd = new SqlCommand(sqlQuery, conn))
          {
            cmd.ExecuteNonQuery();
          }
        }
        MessageBox.Show("OK, SqlConnection and SqlCommand are closed and disposed properly");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error : " + ex);
      }
    
      // Sample using SqlDataAdapter
      try
      {
        var dataTable = new DataTable();
        using (var conn = new SqlConnection(connectionString))
        {
          conn.Open();
          using (var sda = new SqlDataAdapter(sqlQuery, conn))
          {
            sda.Fill(dataTable);
          }
        }
        MessageBox.Show("OK, SqlConnection and SqlDataAdapter are closed and disposed properly, use DataTable here...");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error : " + ex);
      }
