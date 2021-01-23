        public static class ThreadHelper
        {
          
            public static IAsyncAction ExecuteOnUIThread(Windows.UI.Core.DispatchedHandler action)
            {
                return Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, action);
            }
        }
