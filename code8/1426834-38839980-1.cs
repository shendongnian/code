        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootControl = Window.Current.Content as RootControl;
            if (rootControl == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootControl = new RootControl();
                rootControl.RootFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
                // Place the frame in the current Window
                Window.Current.Content = rootControl;
            }
            if (rootControl.RootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootControl.RootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
