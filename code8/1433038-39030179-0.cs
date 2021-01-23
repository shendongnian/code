    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      List<GridViewColumn> cols = NewGridCols();
      viewGridControl.Columns.AddRange(cols);
    }
    private List<GridViewColumn> NewGridCols()
    {
      List<GridViewColumn> cols = new List<GridViewColumn>();
      for (int i = 0; i < 100; i++)
      {
        cols.Add(new GridViewColumn());
      }
      return cols;
    }
