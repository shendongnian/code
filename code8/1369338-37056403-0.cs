                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
                openPicker.FileTypeFilter.Add(".mp3");
                openPicker.FileTypeFilter.Add(".wav");
                openPicker.FileTypeFilter.Add(".mp4");
    
                var file = await openPicker.PickSingleFileAsync();
    
                try
                {
                    var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    playbackElement3.SetSource(stream, file.ContentType);//Play Selected
    
                    playbackElement3.Play();
     
                }
                catch (Exception ex)
                {
    
                }
