    private void gr_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
        object obj = (sender as GridView).SelectedItem;
        IGrouping<string, object> groupCast = obj as System.Linq.IGrouping<string, object>;
        foreach (Item item in groupCast)
           {
              //to do staff
           }
      }
