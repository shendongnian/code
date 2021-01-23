    if (ApplicationData.Current.LocalSettings.Values.ContainsKey("isFirstLaunch"))
    {
        // if that's the first launch, stay, otherwise navigate to Settings.xaml
        if (!(bool)ApplicationData.Current.LocalSettings.Values["isFirstLaunch"])
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(Settings)));
        }
    }
    else
    {
        ApplicationData.Current.LocalSettings.Values["isFirstLaunch"] = false;
    }
