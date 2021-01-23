    public Bitmap RotateImage(Image image, float angle)
    {
        Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
        rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        Graphics g = Graphics.FromImage(rotatedBmp);
        PointF offset = new PointF(image.Width / 2, image.Height / 2);
        g.TranslateTransform(offset.X, offset.Y);
        g.RotateTransform(angle);
        g.TranslateTransform(-offset.X, -offset.Y);
        g.DrawImage(image, new PointF(0, 0));
        return rotatedBmp;
    }   
