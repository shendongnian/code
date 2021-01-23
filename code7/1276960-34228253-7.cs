    var picker = new FileOpenPicker
    {
        SuggestedStartLocation = PickerLocationId.PicturesLibrary
    };
    picker.FileTypeFilter.Add(".jpg");
    picker.FileTypeFilter.Add(".jpeg");
    picker.FileTypeFilter.Add(".png");
    var file = await picker.PickSingleFileAsync();
    if (file != null)
    {
        var bitmap = new BitmapImage();
        await bitmap.SetSourceAsync(await file.OpenReadAsync());
        viewModel.CurrentImage = bitmap;
    }
