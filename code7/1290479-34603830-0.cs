    for (int i = 0; i < bitmapData.Height; i++)
    {
        //the row starts at (i * bitmapData.Stride).
        //we must do this because bitmapData.Stride includes the pad bytes.
        int rowStart = i * bitmapData.Stride;        
        //you need to use bitmapData.Width and bitmapData.PixelFormat
        //  to determine how to parse a row. 
        //assuming 24 bit. (bitmapData.PixelFormat == Format24bppRgb)
        if (bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
        {
            for (int j = 0; j < bitmapData.Width; j++)
            {
                //the pixel is contained in:
                //    bytes[pixelStart] .. bytes[pixelStart + 2];
                int pixelStart = rowStart + j * 3;
            }
        }
    }
