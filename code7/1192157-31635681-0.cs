    async private void SetLocalMedia()
    {
        var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
    
        openPicker.FileTypeFilter.Add(".wmv");
        openPicker.FileTypeFilter.Add(".mp4");
        openPicker.FileTypeFilter.Add(".wma");
        openPicker.FileTypeFilter.Add(".mp3");
    
        var file = await openPicker.PickSingleFileAsync();
    
        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
    
        // mediaControl is a MediaElement defined in XAML
        if (null != file)
        {
            mediaControl.SetSource(stream, file.ContentType);
    
            mediaControl.Play();
        }
    }
