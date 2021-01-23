    protected override void OnFileActivated(FileActivatedEventArgs args)
    {
        //base.OnFileActivated(args);
        var rootFrame = new Frame();
        rootFrame.Navigate(typeof(PlayerPage), args);
        Window.Current.Content = rootFrame;
        Window.Current.Activate();
    }
