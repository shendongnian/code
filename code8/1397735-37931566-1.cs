    public Bitmap GetScreenshot()
    {
                IntPtr hwnd = ihandle;//handle here
    
                RECT rc;
                Win32.GetWindowRect(new HandleRef(null, hwnd), out rc);
    
                Bitmap bmp = new Bitmap(rc.Right - rc.Left, rc.Bottom - rc.Top, PixelFormat.Format32bppArgb);
                Graphics gfxBmp = Graphics.FromImage(bmp);
                IntPtr hdcBitmap;
                try
                {
                    hdcBitmap = gfxBmp.GetHdc();
                }
                catch
                {
                    return null;
                }
                bool succeeded = Win32.PrintWindow(hwnd, hdcBitmap, 0);
                gfxBmp.ReleaseHdc(hdcBitmap);
                if (!succeeded)
                {
                    gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(Point.Empty, bmp.Size));
                }
                IntPtr hRgn = Win32.CreateRectRgn(0, 0, 0, 0);
                Win32.GetWindowRgn(hwnd, hRgn);
                Region region = Region.FromHrgn(hRgn);//err here once
                if (!region.IsEmpty(gfxBmp))
                {
                    gfxBmp.ExcludeClip(region);
                    gfxBmp.Clear(Color.Transparent);
                }
                gfxBmp.Dispose();
                return bmp;
     }
