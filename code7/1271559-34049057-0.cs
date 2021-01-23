     protected override void OnNavigatedFrom(NavigationEventArgs e)
     {
        ApplicationDataContainer AppSettings = ApplicationData.Current.LocalSettings;
        AppSettings.Values["musicV"] = musicVolume.Value;
     }
