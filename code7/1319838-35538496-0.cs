    private void contactDblClicked(MouseButtonEventArgs obj)
    {
      var listView = obj.Source as ListView;
      if (listView != null)
      {
        if (listView.SelectedItem != null)
        {
          Debug.WriteLine("item selected");
        }
        else
        {
          Debug.WriteLine("item not selected");
        }
      }
    }
