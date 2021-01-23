    private void Button_Click(object sender, RoutedEventArgs e)
    {
        FileOpenPicker filePicker = new FileOpenPicker();
        filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        filePicker.ViewMode = PickerViewMode.Thumbnail;
     
        // Filter to include a sample subset of file types
        filePicker.FileTypeFilter.Clear();
        filePicker.FileTypeFilter.Add(".bmp");
        filePicker.FileTypeFilter.Add(".png");
        filePicker.FileTypeFilter.Add(".jpeg");
        filePicker.FileTypeFilter.Add(".jpg");
     
        filePicker.PickSingleFileAndContinue();
        view.Activated += viewActivated; 
    }
