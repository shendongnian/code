            private void App_BackRequested(object sender, BackRequestedEventArgs e)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null)
                    return;
    
                // Navigate back if possible, and if the event has not 
                // already been handled .
                if (rootFrame.CanGoBack && e.Handled == false)
                {
                    e.Handled = true;
                    rootFrame.GoBack();
                }
            }
    
            /// <summary>
            /// Invoked when the application is launched normally by the end user.  Other entry points
            /// will be used such as when the application is launched to open a specific file.
            /// </summary>
            /// <param name="e">Details about the launch request and process.</param>
            protected override void OnLaunched(LaunchActivatedEventArgs e)
            {
    
    //#if DEBUG
    //            if (System.Diagnostics.Debugger.IsAttached)
    //            {
    //                this.DebugSettings.EnableFrameRateCounter = true;
    //            }
    //#endif
    
                Frame rootFrame = Window.Current.Content as Frame;
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();
    
                    rootFrame.NavigationFailed += OnNavigationFailed;
    
                    if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    {
                        //TODO: Load state from previously suspended application
                    }
    
                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                }
    
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
