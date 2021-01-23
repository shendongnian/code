    protected async override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Main);
        _imageView = FindViewById<ImageView>(Resource.Id.resized_imageview);
    
        BitmapFactory.Options options = await GetBitmapOptionsOfImageAsync();
        Bitmap bitmapToDisplay = await LoadScaledDownBitmapForDisplayAsync (Resources, options, 150, 150);
        _imageView.SetImageBitmap(bitmapToDisplay);
    }
    
    public async Task<Bitmap> LoadScaledDownBitmapForDisplayAsync(Resources res, BitmapFactory.Options options, int reqWidth, int reqHeight)
    {
        // Calculate inSampleSize
        options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);
    
        // Decode bitmap with inSampleSize set
        options.InJustDecodeBounds = false;
    
        return await BitmapFactory.DecodeResourceAsync(res, Resource.Drawable.samoyed, options);
    }
