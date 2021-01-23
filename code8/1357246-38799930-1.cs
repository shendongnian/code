    int idCreate = 0; List<int> idSaved = new List<int>();
    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
            rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            Window.Current.Content = rootFrame;
        }
        if (rootFrame.Content == null)
        {
            rootFrame.Navigate(typeof(MainPage), e.Arguments);
            idSaved.Add(ApplicationView.GetForCurrentView().Id);
        }
        else
        {
            var create = CoreApplication.CreateNewView(); 
            await create.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(MainPage), e.Arguments);
                Window.Current.Content = frame;
                Window.Current.Activate();
                idCreate = ApplicationView.GetForCurrentView().Id;
            });
            for(int i = idSaved.Count - 1; i >= 0; i--)
                if (await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                        idCreate, ViewSizePreference.UseMinimum, 
                        idSaved[i], ViewSizePreference.UseMinimum)
                   ) break;
            idSaved.Add(idCreate);
        }
        Window.Current.Activate();
    }
