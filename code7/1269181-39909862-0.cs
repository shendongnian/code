    private async void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        //FileOpePicker 설정
        var openDlg = new FileOpenPicker();
        openDlg.FileTypeFilter.Add(".jpg");
        openDlg.FileTypeFilter.Add(".jpeg");
        openDlg.FileTypeFilter.Add(".png");
        //파일 선택 창 출력
        var result = await openDlg.PickSingleFileAsync();
        if (result == null || !result.IsAvailable) return;
        var file = await StorageFile.GetFileFromPathAsync(result.Path);
        var property = await file.Properties.GetImagePropertiesAsync();
        //이미지 크기 만큼 비트맵 생성
        var writeableBmp = BitmapFactory.New((int)property.Width, (int)property.Height);
        using (writeableBmp.GetBitmapContext())
        {
            //선택한 파일 이미지로 불러오기
            using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                writeableBmp = await BitmapFactory.New(1, 1).FromStream(fileStream, BitmapPixelFormat.Bgra8);
            }
        }
        FacePhoto.Source = writeableBmp;
        //Face API이 DetectAsync를 이용해서 얼굴 찾기
        using (var imageFileStream = await file.OpenStreamForReadAsync())
        {
            var faces = await faceServiceClient.DetectAsync(imageFileStream);
            if (faces == null) return;
            //얼굴 위치 표시
            foreach (var face in faces)
            {
                writeableBmp.DrawRectangle(face.FaceRectangle.Left, face.FaceRectangle.Top,
                face.FaceRectangle.Left + face.FaceRectangle.Width,
                face.FaceRectangle.Top + face.FaceRectangle.Height, Colors.Red);
            }
        }
    }
