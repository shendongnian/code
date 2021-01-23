     protected override void OnLaunched(LaunchActivatedEventArgs e)
            {
                Frame rootFrame = Window.Current.Content as Frame;
    
                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                var shell = Window.Current.Content as Shell;
                if (rootFrame == null)
                {
                    rootFrame = null;
                    if (shell == null)
                    {
    
                        if (rootFrame == null)
                        {
                            rootFrame = new Frame();
                            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
    
                            rootFrame.NavigationFailed += OnNavigationFailed;
    
                            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                            {
                            }
                        }
    
                        //shell.NewFrame = rootFrame;
                        shell = new Shell(rootFrame);
                        Window.Current.Content = shell;
                    }
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
