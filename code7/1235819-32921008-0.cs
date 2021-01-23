    public static Bitmap GetBitmap()
    {
        byte[] byteArray = bring it from somewhere
        using (Stream stream = new MemoryStream(byteArray))
        {
            var tempBitmap = new Bitmap(stream);
            return new Bitmap(tempBitmap); // This will deep-copy the Bitmap
        }
    }
