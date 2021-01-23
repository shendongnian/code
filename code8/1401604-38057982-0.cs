        Timer collapseTimer;
        internal void collapseAll()
        {
            collapseTimer = new Timer(collapseCallBack, null, 0, Timeout.Infinite);
        }
        private async void collapseCallBack(object state)
        {
            foreach (var item in views)
            {
               var asyncAction =  CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
             {
                 item.IsCollapsed = true;
             });
                await Task.Delay(10);
            }
            collapseTimer.Dispose();
        }
