    var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
    openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
    openPicker.FileTypeFilter.Add(".mp3");
    
    var pickedFile = await openPicker.PickSingleFileAsync();
    if (pickedFile != null)
    {
        //Created encoding profile based on the picked file
        var encodingProfile = await MediaEncodingProfile.CreateFromFileAsync(pickedFile);
        var clip = await MediaClip.CreateFromFileAsync(pickedFile);
    
        // Trim the front and back 25% from the clip
        clip.TrimTimeFromStart = new TimeSpan((long)(clip.OriginalDuration.Ticks * 0.25));
        clip.TrimTimeFromEnd = new TimeSpan((long)(clip.OriginalDuration.Ticks * 0.25));
        var composition = new MediaComposition();
        composition.Clips.Add(clip);
    
        var savePicker = new Windows.Storage.Pickers.FileSavePicker();
        savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
        savePicker.FileTypeChoices.Add("MP3 files", new List<string>() { ".mp3" });
        savePicker.SuggestedFileName = "TrimmedClip.mp3";
    
        StorageFile file = await savePicker.PickSaveFileAsync();
        if (file != null)
        {
            //Save to file using original encoding profile
            var result = await composition.RenderToFileAsync(file, MediaTrimmingPreference.Precise, encodingProfile);
    
            if (result != Windows.Media.Transcoding.TranscodeFailureReason.None)
            {
                System.Diagnostics.Debug.WriteLine("Saving was unsuccessful");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Trimmed clip saved to file");
            }
        }
    }
