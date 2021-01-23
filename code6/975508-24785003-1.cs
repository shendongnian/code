    var picker = new Xamarin.Media.MediaPicker();
    btnCamera.Hidden = !picker.IsCameraAvailable;
    btnCamera.TouchUpInside += async (sender, e) =>
    {
        try
        {
            MediaFile file = 
                await picker.TakePhotoAsync(new StoreCameraMediaOptions());
            processImage(file);
        }
        catch { }
    };
    btnPhoto.Hidden = !picker.PhotosSupported;
    btnPhoto.TouchUpInside += async (sender, e) =>
    {
        try
        {
            MediaFile file = await picker.PickPhotoAsync();
            processImage(file);
        }
        catch { }
    };
    private void processImage(MediaFile file)
    {
        if (file != null)
        {
            viewModel.Image = file.GetStream();
            viewModel.ImagePath = file.Path;
            setImage();
        }
    }
    private void setImage()
    {
        try
        {
            System.Diagnostics.Debug.WriteLine(viewModel.ImagePath);
            if (!string.IsNullOrEmpty(viewModel.ImagePath) &&
                System.IO.File.Exists(viewModel.ImagePath))
            {
                imgImage.Image = new UIImage(NSData.FromFile(viewModel.ImagePath));
            }
            else if (viewModel.Image != null && viewModel.Image.Length != 0)
            {
                imgImage.Image = new UIImage(NSData.FromStream(viewModel.Image));
            }
        }
        //just don't load image
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }
