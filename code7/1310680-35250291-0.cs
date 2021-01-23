    public async Task OpenAsync(Type page, object parameter = null, string title = null, ViewSizePreference size = ViewSizePreference.UseHalf)
    {
        DebugWrite($"Page: {page}, Parameter: {parameter}, Title: {title}, Size: {size}");
        var currentView = ApplicationView.GetForCurrentView();
        title = title ?? currentView.Title;
        var newView = CoreApplication.CreateNewView();
        var dispatcher = new DispatcherWrapper(newView.Dispatcher);
        await dispatcher.DispatchAsync(async () =>
        {
            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = title;
            var nav = BootStrapper.Current.NavigationServiceFactory(BootStrapper.BackButton.Ignore, BootStrapper.ExistingContent.Exclude);
            nav.Navigate(page, parameter);
            newWindow.Content = (nav as INavigationServiceInternal).FrameFacade.Frame;
            newWindow.Activate();
            await ApplicationViewSwitcher
                .TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.Default, currentView.Id, size);
        });
    }
