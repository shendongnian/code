    protected virtual async void pickFile(object sender, RoutedEventArgs e)
    {
         await PickFileAsync();
    }
    protected async Task PickFileAsync()
    {
        var picker = new FileOpenPicker();
        picker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
        picker.FileTypeFilter.Add(".wmv");
        picker.FileTypeFilter.Add(".mp4");
        var file = await picker.PickSingleFileAsync();
        if (file == null) return;
        inputFile = file;
    }
