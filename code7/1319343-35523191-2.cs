    public static Bitmap ApplyGamma(Bitmap bmp0, float gamma)
    {
        Bitmap bmp1 = new Bitmap(bmp0.Width, bmp0.Height);
        using (Graphics g = Graphics.FromImage(bmp1))
        {
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            g.DrawImage(bmp0, new Rectangle(0, 0, bmp0.Width, bmp0.Height),
                        0, 0, bmp0.Width, bmp0.Height, GraphicsUnit.Pixel, attributes);
        }
        return bmp1;
    }
