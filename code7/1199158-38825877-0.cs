    using global::Windows.ApplicationModel.Core;
    using global::Windows.UI.Core;
    public static class UIThread
    {
        private static readonly CoreDispatcher Dispatcher;
    
        static DispatcherExt()
        {
            Dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
        }
    
        public static async Task Run(DispatchedHandler handler)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, handler);
        }
    }
