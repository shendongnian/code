    public async void Window_Loaded(object sender, RoutedEventArgs e)
    {
      await firstLoadAsync();
    }
    private List<FilterType> InitializeFilter()
    {
      //... some lines of code that takes some time to run. 
    }
    private async Task firstLoadAsync()
    {
      LW.Title = "Loading...";
      LW.Show();
      filterTextBox.Text = defaultSearch;
      var filterData = await Task.Run(() => InitializeFilter()); // Get the plain data on a background thread
      myCollectionView = new CollectionView(filterData); // Update the UI
      if (LW != null)
      {
        LW.closable = true;
        LW.Close();
      }
    }
