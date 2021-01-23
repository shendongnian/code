    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ApplicationDataContainer AppSettings = ApplicationData.Current.LocalSettings;
        if (AppSettings.Values.ContainsKey("musicV"))
        {
            musicVolume.Value = (double)AppSettings.Values["musicV"];
        }
    }
