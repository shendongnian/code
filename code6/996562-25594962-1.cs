    WritableBitmap ret = BitmapFactory.New(img_width, img_height);
    ret.Lock();
    var bmp = new System.Drawing.Bitmap(
        ret.PixelWidth,
        ret.PixelHeight,
        ret.BackBufferStride,
        System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
        ret.BackBuffer
    );
    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
    g.DrawArc(...); //<-- draws an antialiased arc with variable thickness
    g.Dispose();
    bmp.Dispose();
    ret.AddDirtyRect(new Int32Rect(0, 0, ret.PixelWidth, ret.PixelHeight));
    ret.Unlock();
    return ret; //<-- WritableBitmap with beautifull arc on it;
