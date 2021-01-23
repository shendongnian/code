    using System.Runtime.InteropServices;
    //... 
       
    [DllImport("gdi32.dll")]
    public static extern int BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth,
        int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, int  dwRop);
    //..
        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppRgb);
        using (Graphics gdest = Graphics.FromImage(screenPixel))
        {
            using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr hSrcDC = gsrc.GetHdc();
                IntPtr hDC = gdest.GetHdc();
                int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, x, y, (int)0x00CC0020);
                gdest.ReleaseHdc();
                gsrc.ReleaseHdc();
            }
        }
        Color c =  screenPixel.GetPixel(0, 0);
        return c;
