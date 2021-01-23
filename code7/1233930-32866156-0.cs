    private async void SearchPaneButton_Click(object sender, EventArgs e)
    {
      if (SynchronizationContext.Current == null)
        SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
      await SearchAsync();
    }
    private async Task SearchAsync()
    {
      var searchText = SearchTextBox.Text;
      SearchPaneButton.Text = "Loading…";
      var data = await new DataServiceClient().GetDataAsync(searchText);
      SearchPaneButton.Text = "Search";
      ToggleWorkbookEvents();
    }
