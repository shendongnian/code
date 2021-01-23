    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
       ...
        var applicationMergedDics = Application.Current.Resources.MergedDictionaries;
        applicationMergedDics[0].MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("ms-appx:///Styles/Shared.xaml") });
        applicationMergedDics[0].MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("ms-appx:///Styles/Templates.xaml") });
        ...
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
    }
