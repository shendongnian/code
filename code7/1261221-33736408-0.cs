     Loaded += navigate_pause();
       
     private RoutedEventHandler navigate_pause() 
     {
            Dispatcher.BeginInvoke(() =>
            {
                ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/Pause.xaml", UriKind.Relative));
            });
            return null;
     }
