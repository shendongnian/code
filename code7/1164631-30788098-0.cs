    GridViewColumnHeader _lastHeaderClicked = null;
    ListSortDirection _lastDirection = ListSortDirection.Ascending;
    
    void GridViewColumnHeaderClickedHandler(object sender,RoutedEventArgs e)
    {
      GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
      ListSortDirection direction;
    
      if (headerClicked != null)
      {
          if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
          {
              if (headerClicked != _lastHeaderClicked)
              {
                 direction = ListSortDirection.Ascending;
              }
              else
              {
                 if (_lastDirection == ListSortDirection.Ascending)
                 {
                   direction = ListSortDirection.Descending;
                 }
                 else
                 {
                     direction = ListSortDirection.Ascending;
                 }
              }
    
              string header = headerClicked.Column.Header as string;
              Sort(header, direction);
    
              _lastHeaderClicked = headerClicked;
              _lastDirection = direction;
           }
        }
      }
     private void Sort(string sortBy, ListSortDirection direction)
     {
      ICollectionView dataView =
        CollectionViewSource.GetDefaultView(lv.ItemsSource);
      dataView.SortDescriptions.Clear();
      SortDescription sd = new SortDescription(sortBy, direction);
      dataView.SortDescriptions.Add(sd);
      dataView.Refresh();
