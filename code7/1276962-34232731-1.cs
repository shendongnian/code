    public ImageSource CurrentImage
    {
        get { return currentImage; }
        set { SetValue(ref currentImage, value); }
    }
    public async Task SetCurrentImageAsync(StorageFile file) {
        var bitmap = new BitmapImage();
        await bitmap.SetSourceAsync(await file.OpenReadAsync());
        this.CurrentImage = bitmap;
    }
