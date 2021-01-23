    protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {                
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Here you can navigate to some other pages if saved some sort of state
                }                
                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                // Replace MainPage with your desire page
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            
            Window.Current.Activate();
        }
