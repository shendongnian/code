        public static async Task TryShowNewWindow<TView>(bool switchToView)
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
            var viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            if (switchToView && viewShown)
            {
                // Switch to new view
                await ApplicationViewSwitcher.SwitchAsync(newViewId);
            }
        }
