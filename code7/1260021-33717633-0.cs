    async private void Button_Click(object sender, RoutedEventArgs e)
     {
     CoreApplicationView newView = CoreApplication.CreateNewView();
     int newViewId = 0;
    
    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
     {
     var frame = new Frame();
     frame.Navigate(typeof(MainPage), newViewId);
     Window.Current.Content = frame;
    
    // In Windows 10 UWP we need to activate our view first.
     // Let's do it now so that we can use TryShow...() and SwitchAsync().
     Window.Current.Activate();
    
    newViewId = ApplicationView.GetForCurrentView().Id;
     });
    
     bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
     }
