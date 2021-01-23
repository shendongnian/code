    public byte[] SaveImage() {
        DrawingCacheEnabled = true;                  //Enable cache for the next method below
        Bitmap bitmap       = GetDrawingCache(true); //Gets the image from the cache
        byte[] bitmapData;
        using(MemoryStream stream = new MemoryStream()) {
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            bitmapData = stream.ToArray();
        }
        return bitmapData;
    }
