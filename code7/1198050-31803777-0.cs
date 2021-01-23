    public static bool TryShowNewWindow<TView>()
    {
        var newView = CoreApplication.CreateNewView();
        int newViewId = 0;
        await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            var frame = new Frame();
            frame.Navigate(typeof(TView), null);
            Window.Current.Content = frame;
            newViewId = ApplicationView.GetForCurrentView().Id;
        });
        return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
    }
