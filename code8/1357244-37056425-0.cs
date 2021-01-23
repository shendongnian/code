    public bool isMainViewClosed = false;
    public ObservableCollection<CoreApplicationView> secondaryViews = new ObservableCollection<CoreApplicationView>();
    //...
    protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                alreadyLaunched = true;
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            else if(alreadyLaunched)
            {
		//If the main view is closed, use the thread of one of the views that are still open
                if(isMainViewClosed)
                {
                    int newViewId = 0;
                    await secondaryViews[0].Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        var currentPage = (MainPage)((Frame)Window.Current.Content).Content;
                        Window.Current.Activate();
                        currentPage.NewWindow();
                        newViewId = ApplicationView.GetForCurrentView().Id;
                    });
                    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
                }
                else
                {
                    CoreApplicationView newView = CoreApplication.CreateNewView();
                    int newViewId = 0;
                    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Frame frame = new Frame();
                        frame.Navigate(typeof(MainPage), null);
                        Window.Current.Content = frame;
                        var currentPage = (MainPage)((Frame)Window.Current.Content).Content;
                        Window.Current.Activate();
                        secondaryViews.Add(CoreApplication.GetCurrentView());
                        newViewId = ApplicationView.GetForCurrentView().Id;
                    });
                    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
                }
            }
            Window.Current.Activate();
        }
