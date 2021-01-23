        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
        openPicker.FileTypeFilter.Add(".mp3");
        StorageFile file = await openPicker.PickSingleFileAsync();
        IRandomAccessStreamWithContentType content = await file.OpenReadAsync();
        Debug.WriteLine("Content Type: " + content.ContentType);
        player.SetSource(content, content.ContentType);
