    protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
            rootFrame = new Frame();
            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
            rootFrame.NavigationFailed += OnNavigationFailed;
            Window.Current.Content = rootFrame;
        }
        rootFrame.Navigate(typeof(MainPage), args.ShareOperation);
        Window.Current.Activate();           
    }
