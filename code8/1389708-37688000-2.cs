    using(var connection = new OleDbConnection("{your-connection-string}"))
    {
          // Build your query with parameters
          var query = "UPDATE ? SET [Inventory Status] = 'FOUND' WHERE [Inventory number] LIKE ?";
          using(var command = new OleDbCommand(query, connection))
          {
               connection.Open();
               // Add your parameters
               command.Parameters.AddWithValue("@table",lstCompCode.SelectedValue);
               command.Parameters.AddWithValue("@search", "*" + txtAssetScanned.Text);
               // Now that your queries are added, perform your update
               command.ExecuteNonQuery();
          }
    }
   
