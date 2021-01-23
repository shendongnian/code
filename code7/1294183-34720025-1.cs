    protected async override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);
            var continuationManager = new ContinuationManager();
            var rootFrame = CreateRootFrame();
            await RestoreStatusAsync(args.PreviousExecutionState);
            
            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(MainPage));
            }
            var continuationEventArgs = e as IContinuationActivatedEventArgs;
            if (continuationEventArgs != null)
            {
                Frame scenarioFrame = MainPage.Current.FindName("ScenarioFrame") as Frame;
                if (scenarioFrame != null)
				{
                    // Call ContinuationManager to handle continuation activation
                    continuationManager.Continue(continuationEventArgs, scenarioFrame);
                }
            }
           
            Window.Current.Activate();
        }
