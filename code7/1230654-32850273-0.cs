        private void GamePage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            Frame rootFrame = Window.Current.Content as Frame;            
            if (rootFrame.CanGoBack)
            {
                var d = dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => ShowConfirmationDialog(rootFrame));
            }
        }
        public async void ShowConfirmationDialog(Frame rootFrame)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Are you sure ?");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No") { Id = 1 });
            var result = await dialog.ShowAsync();
            if (result != null && result.Label == "Yes")
            {
                rootFrame.GoBack();
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
            SystemNavigationManager.GetForCurrentView().BackRequested += GamePage_BackRequested;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= GamePage_BackRequested;
        }
