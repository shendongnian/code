    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      ItemsControl ItemsControl = UCEnvironmentControl.GetItemsControlPhotos();
      Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() => Control.PointToScreen(new Point(0,0));
    }
