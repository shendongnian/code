    public static Bitmap cropAtRect(Bitmap b, Rectangle r)
    {
        Bitmap nb = new Bitmap(r.Width, r.Height);
        Graphics g = Graphics.FromImage(nb);
        Rectangle destRect = new Rectangle(0, 0, r.Width, r.Height); //Set destination rect
        g.DrawImage(b, destRect, r, GraphicsUnit.Pixel);
        return nb;
    }
