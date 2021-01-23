         protected override void OnLaunched(LaunchActivatedEventArgs e)
         {
        #if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
        #endif
            Frame rootFrame = Window.Current.Content as Frame;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new ThemeAwareFrame(ElementTheme.Dark);
                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }
         //..
