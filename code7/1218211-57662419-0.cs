     protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
            {
                await OnInitializeAsync();
    
                if (await CheckToken(args) != true) return;
    
                if (args.PreviousExecutionState != ApplicationExecutionState.Running)
                {
                    if (await LoadData(args) != true) return;
                }
    
                var frame = new Frame();
                Window.Current.Content = frame;
                var dispatchService = new DispatcherService() { Dispatcher = CoreWindow.GetForCurrentThread().Dispatcher };
                var navigationService = new NavigationService(dispatchService) { RootFrame = frame };
                navigationService.Navigate<ShareViewModel>(args.ShareOperation);
                Window.Current.Activate();
            }
