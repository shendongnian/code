    private static void RunOnUIThread(Action callback)
    {
        //<---- Currently NOT on the UI-thread
        Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            //Do some UI-code that must be run on the UI thread.
        }).GetResults();
        callback();
    }
