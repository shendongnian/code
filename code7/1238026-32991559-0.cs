    Bitmap result = new Bitmap(image.Width, image.Height, PixelFormat.Format16bppRgb565);
    using (Graphics g = Graphics.FromImage(result))
    {
        g.DrawImage(image, 0, 0, image.Width, image.Height);
    }
