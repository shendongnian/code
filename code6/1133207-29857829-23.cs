    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (hBitmapForm != IntPtr.Zero)
        {
            SelectObject(hdcMemForm, hBitmapFormOld);
            DeleteObject(hBitmapForm);
            DeleteDC(hdcMemForm);
            hdcMemForm = IntPtr.Zero;
            hBitmapForm = IntPtr.Zero;
        }
        if (hBitmapTransparent != IntPtr.Zero)
        {
            SelectObject(hdcMemTransparent, hBitmapTransparentOld);
            DeleteObject(hBitmapTransparent);
            DeleteDC(hdcMemTransparent);
            hdcMemTransparent = IntPtr.Zero;
            hBitmapTransparent = IntPtr.Zero;
        }
        if (hBitmapGreenOpacityX != IntPtr.Zero)
        {
            SelectObject(hdcMemGreenOpacityX, hBitmapGreenOpacityXOld);
            DeleteObject(hBitmapGreenOpacityX);
            DeleteDC(hdcMemGreenOpacityX);
            hdcMemGreenOpacityX = IntPtr.Zero;
            hBitmapGreenOpacityX = IntPtr.Zero;
        }
        if (hBitmapGreenOpacityY != IntPtr.Zero)
        {
            SelectObject(hdcMemGreenOpacityY, hBitmapGreenOpacityYOld);
            DeleteObject(hBitmapGreenOpacityY);
            DeleteDC(hdcMemGreenOpacityY);
            hdcMemGreenOpacityY = IntPtr.Zero;
            hBitmapGreenOpacityY = IntPtr.Zero;
        }
        if (bitmapForm != null)
        {
            bitmapForm.Dispose();
            bitmapForm = null;
        }
        if (bitmapTransparent != null)
        {
            bitmapTransparent.Dispose();
            bitmapTransparent = null;
        }
        if (bitmapGreenOpacityX != null)
        {
            bitmapGreenOpacityX.Dispose();
            bitmapGreenOpacityX = null;
        }
        if (bitmapGreenOpacityY != null)
        {
            bitmapGreenOpacityY.Dispose();
            bitmapGreenOpacityY = null;
        }
    }
