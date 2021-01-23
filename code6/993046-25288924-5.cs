    private unsafe void CreateArray(Bitmap bmp)
    {
        // Note that is it somewhat a standard
        // to define 2d array access by [y,x] (not [x,y])
        bool[,] bwValues = new bool[bmp.Height, bmp.Width];
        // Lock the bitmap's bits.  
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        System.Drawing.Imaging.BitmapData bmpData =
            bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            bmp.PixelFormat);
        // Get the address of the first line.
        byte* ptr = (byte*)bmpData.Scan0;
        // Declare an array to hold the bytes of the bitmap. 
        int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
        for (int y = 0; y < bmp.Height; y++)
        {
            var row = ptr + (y * bmpData.Stride);
            for (int x = 0; x < bmp.Width; x++)
            {
                var pixel = row + x * 4; // ARGB has 4 bytes per pixel
                // A bit=0
                // R bit=1
                // G bit=2
                // B bit=3
                // (depending on your image pixel format)
                // Check if A = R = G = B = 255 (meaning the pixel is white)
                bool isWhite = (pixel[0] == 255 &&
                                pixel[1] == 255 &&
                                pixel[2] == 255 &&
                                pixel[3] == 255);
                // Assume that anything that isn't white is black
                bwValues[y, x] = isWhite;
            }
        }
        // Do whatever you want with vwValues here
    }
