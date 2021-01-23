    async Task<DataTable> LoadData()
    {
      // Setup the command, connection etc. as usual
      using (var reader = await command.ExecuteReaderAsync())
      {
        var results = new DataTable();
        results.Load(reader);
        return results;
      }
    }
    async void btnDoStuff_Click(object sender, EventArgs e)
    {
      try
      {
        loadingAnimation.Show();
        var dataTable = await LoadData();
        
        // Use the data table to bind the ListView's data as usual
      }
      finally
      {
        loadingAnimation.Hide();
      }
    }
