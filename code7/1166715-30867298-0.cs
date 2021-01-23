    private void tabControlOrganizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       if (tabControlOrganizer.SelectedItem != null)
       {
          if (e.Source is TabControl)
          {
            if (tabItemTrades.IsSelected)
            {
              dataGridTrades.ItemsSource = Queries.GetTradeList(dataContext);
            }
