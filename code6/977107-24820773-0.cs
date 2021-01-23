    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
        string key = "Font-Size";
        IsolatedStorageSettings.ApplicationSettings[key] = (fontlistpicker.SelectedItem as ListPickerItem).Content.ToString();
    }
