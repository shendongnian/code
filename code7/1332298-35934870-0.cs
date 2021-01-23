        private async void OnClick(object sender, RoutedEventArgs e)
        {
            var newCoreAppView = CoreApplication.CreateNewView();
            var appView = ApplicationView.GetForCurrentView();
            await newCoreAppView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, async () =>
            {
                var window = Window.Current;
                var newAppView = ApplicationView.GetForCurrentView();
               
                var frame = new Frame();
                window.Content = frame;
                
                frame.Navigate(typeof(BlankPage));            
                window.Activate();
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.Default, appView.Id, ViewSizePreference.Default);
    
            });
        }
