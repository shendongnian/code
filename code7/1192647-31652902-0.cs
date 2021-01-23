    StorageFolder sdcard;
    public async void read_sdcard_button_click(object sender, RoutedEventArgs e)
    {
        sdcard = (await KnownFolders.RemovableDevices.GetFoldersAsync()).FirstOrDefault();
    }
    private void some_other_method()
    {
        textbox.Text = sdcard.path;
    }
