    int prevCookie = 0;
    private void testMethod(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(100, 100);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            //Draw some shapes on bitmap
        }
        int hBitmap = bmp.GetHBitmap().ToInt32();
        //I used intel media sdk library.
        int newCookie;
        intelMediaSdkVariable.AddImageFromHandle(hBitmap, out newCookie);
        if (prevCookie > 0)
            intelMediaSdkVariable.RemoveItem2(prevCookie);
        prevCookie = newCookie;
        DeleteObject((IntPtr)hBitmap);   // <---------- You dont have this line.
        bmp.Dispose();
    }
