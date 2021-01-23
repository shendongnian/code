    byte[] _imageData
    public BitmapSource ReadBitmap(int w, int h, int s )
    {
        int size = w*h*3 + 54;
    
        _imageData = new byte[size];
        
        // Read from pipe Read(_temp, 0, size);
        // Or use PInvoke to get a reference and manage that
    
        return BitmapSource.Create(w, h, 96, 96, PixelFormats.Rgb24, null, _imageData, s);
    }
