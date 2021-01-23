    private void contactDblClicked(MouseButtonEventArgs obj)
    {
      if (((FrameworkElement) obj.OriginalSource).DataContext is YourRosterItemXType)
      {
        Debug.WriteLine("item was *really* clicked");
      }
    }
