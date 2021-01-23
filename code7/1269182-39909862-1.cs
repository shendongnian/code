    private async void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        //FileOpePicker
        var openDlg = new FileOpenPicker();
        openDlg.FileTypeFilter.Add(".jpg");
        openDlg.FileTypeFilter.Add(".jpeg");
        openDlg.FileTypeFilter.Add(".png");
        //Open file selection window
        var result = await openDlg.PickSingleFileAsync();
        if (result == null || !result.IsAvailable) return;
        var file = await StorageFile.GetFileFromPathAsync(result.Path);
        var property = await file.Properties.GetImagePropertiesAsync();
        //Create bitmap from image size
        var writeableBmp = BitmapFactory.New((int)property.Width, (int)property.Height);
        using (writeableBmp.GetBitmapContext())
        {
            //Load bitmap from image file
            using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                writeableBmp = await BitmapFactory.New(1, 1).FromStream(fileStream, BitmapPixelFormat.Bgra8);
            }
        }
        //find face that DetectAsync Face API
        using (var imageFileStream = await file.OpenStreamForReadAsync())
        {
            var faces = await faceServiceClient.DetectAsync(imageFileStream);
            if (faces == null) return;
            //display rect
            foreach (var face in faces)
            {
                writeableBmp.DrawRectangle(face.FaceRectangle.Left, face.FaceRectangle.Top,
                face.FaceRectangle.Left + face.FaceRectangle.Width,
                face.FaceRectangle.Top + face.FaceRectangle.Height, Colors.Red);
            }
        }
        FacePhoto.Source = writeableBmp;
    }
