    async void acc_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
    {
        var view = Windows.ApplicationModel.Core.CoreApplication.MainView;
        var window = view.CoreWindow;
        var dispatcher = window.Dispatcher;
        await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { numberAcc++; });
    }
