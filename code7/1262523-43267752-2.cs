    List<System.Drawing.Bitmap> bmpLst = new List<System.Drawing.Bitmap>();
    
    using (var msTemp = new MemoryStream(data))
    {
        TiffBitmapDecoder decoder = new TiffBitmapDecoder(msTemp, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
        int totFrames = decoder.Frames.Count;
    
        for (int i = 0; i < totFrames; ++i)
        {
            // Create bitmap to hold the single frame
            System.Drawing.Bitmap bmpSingleFrame = BitmapFromSource(decoder.Frames[i]);
            // add the frame (as a bitmap) to the bitmap list
            bmpLst.Add(bmpSingleFrame);
        }
    }
