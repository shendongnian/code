    async Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync()
    {
        BitmapFactory.Options options = new BitmapFactory.Options
        {
            InJustDecodeBounds = true
        };
    
        // The result will be null because InJustDecodeBounds == true.
        Bitmap result=  await BitmapFactory.DecodeResourceAsync(Resources, Resource.Drawable.someImage, options);
    
        int imageHeight = options.OutHeight;
        int imageWidth = options.OutWidth;
    
        _originalDimensions.Text = string.Format("Original Size= {0}x{1}", imageWidth, imageHeight);
    
        return options;
    }
