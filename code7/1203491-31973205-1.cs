    private unsafe Bitmap CodeImage(Bitmap bmp)
    {
        Bitmap bmpRes = new Bitmap(bmp.Width, bmp.Height);
        BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
        IntPtr scan0 = bmData.Scan0;
        int stride = bmData.Stride;
        int nWidth = bmp.Width;
        int nHeight = bmp.Height;
        int minX = 10000 ;
        int minY = 1000;
        int width=0;
        var height= 0;
        bool found = false;
        for (int y = 0; y < nHeight; y++)
        {
            byte* p = (byte*)scan0.ToPointer();
            p += y * stride;
            for (int x = 0; x < nWidth; x++)
            {
                if (p[0] == 255 && p[1] == 0 && p[2] == 0 && p[3] != 0)  //Check if pixel is blue;
                {
                    found = true;
                    if (x < minX)
                        minX = x;
                    if (y < minY)
                        minY = y;
                    if (x > width)
                        width = x;
                    if (y > height)
                        height = y;
                }
                p += 4;
            }
        }
        if (found)
        {
            //add one for the width and height
            Rectangle temp = new Rectangle(minX, minY, width - minX + 1, height - minY + 1);
            MessageBox.Show(temp.Top.ToString() + "," + temp.Left.ToString() + ", " + temp.Width.ToString() + ", " + temp.Height.ToString());
            return bmp.Clone(temp, bmp.PixelFormat);
        }
        return null;
    }
