    public Bitmap GetDataPicture(int w, int h, byte[] data)
    {
        Bitmap pic = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                int arrayIndex = y * w + x;
                Color c = palette[arrayIndex];
                pic.SetPixel(x, y, c);
            }
        }
 
        return pic;
    } 
