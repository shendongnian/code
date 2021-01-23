    public BitmapSource loadBitmap(System.Drawing.Bitmap source)
    {
        ....
        finally
        {
            DeleteObject(ip);
            source.Dispose();
        }
    
        return bs;
    }
