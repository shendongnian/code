    using(var connection = new SqlConnection("{your-connection-string}"))
    {
          // Get your query
          var query = "UPDATE @table SET [Inventory Status] = 'FOUND' WHERE [Inventory number] LIKE @search";
          using(var command = new SqlCommand(query, connection))
          {
               connection.Open();
               // Add your parameters
               command.Parameters.AddWithValue("@table",lstCompCode.SelectedValue);
               command.Parameters.AddWithValue("@search", "%" + txtAssetScanned.Text);
               // Now that your queries are added, perform your update
               command.ExecuteNonQuery();
          }
    }
   
