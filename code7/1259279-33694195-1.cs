    private void toggleFilterOn(object sender, RoutedEventArgs e)
    {
      var filterItem = (sender as CheckBox);
      var parent = filterItem.FindAncestorOfType<ContextMenu>();
      var children = parent.FindAllChildren().Where(item => item is CheckBox);
      foreach (CheckBox cb in children)
      {
          cb.IsChecked = false;
      }  
    }
    
