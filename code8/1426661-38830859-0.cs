    public async void UpdateSales()
    {
      var collection = await Task.Run(() =>
      {
        // Some code Create Collection ...
        // Some code with business logic  ..
        return currentCollection;
      });
      saleDataGrid.ItemsSource = collection;
      saleDataGrid.Items.Refresh();
    }
