    public Bitmap GetDesktopImage(Rectangle bounds)
    {
        var bm = new Bitmap(bounds.Width, bounds.Height);
        using (Graphics g = Graphics.FromImage(bm))
        {
            g.CopyFromScreen(bounds.Location, new Point(0, 0),
                bounds.Size, CopyPixelOperation.SourceCopy);
        }
        return bm;
    }
