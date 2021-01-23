    public static Bitmap PaintOn32bpp(Image image)
    {
        Bitmap bp = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
        using (Graphics gr = Graphics.FromImage(bp))
            gr.DrawImage(image, new Rectangle(0, 0, bp.Width, bp.Height));
        return bp;
    }
