    private async void Button_Click_2(object sender, RoutedEventArgs e)
    {
        var picker = new FileOpenPicker();
        picker.ViewMode = PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        picker.FileTypeFilter.Add(".jpeg");
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".png");
        var file = await picker.PickSingleFileAsync();
        if (file != null)
        {
            var stream = await file.OpenStreamForReadAsync();
            var bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
        }
    }
