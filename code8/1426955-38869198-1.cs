    private Frame CreateRootFrame()
    {
        Frame rootFrame = Window.Current.Content as Frame;
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (rootFrame == null)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();
            // Set the default language
            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
            rootFrame.NavigationFailed += OnNavigationFailed;
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }
        return rootFrame;
    }
