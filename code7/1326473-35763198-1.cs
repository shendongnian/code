    private void image_Loading(FrameworkElement sender, object args)
    { 
      progressring.IsActive = true;
    }
    
    private void image_Loaded(object sender, RoutedEventArgs e)
    {
      progressring.IsActive = false;
    }
