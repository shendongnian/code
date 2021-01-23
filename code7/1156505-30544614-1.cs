    BGRA BGRA BGRA BGRA
    BGRA BGRA BGRA BGRA
    BGRA BGRA BGRA BGRA 
    stride = width*bytesPerPixel = 4*4 = 16
    height = 3
    maxLenght = stride*height= 16*3 = 48
_____
       
        public unsafe void Test(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            //TODO determine bytes per pixel
            int bytesPerPixel = 4; // we assume that image is Format32bppArgb
            int maxPointerLenght = width * height * bytesPerPixel;
            int stride = width * bytesPerPixel;
            byte R, G, B, A;
            BitmapData bData = bmp.LockBits(
                new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, bmp.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            for (int i = 0; i < maxPointerLenght; i += 4)
            {
                B = scan0[i + 0];
                G = scan0[i + 1];
                R = scan0[i + 2];
                A = scan0[i + 3];
                // do anything with the colors
            }
            bmp.UnlockBits(bData);
        }
