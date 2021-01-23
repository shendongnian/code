    using System.Drawing.Imaging;
    ..
    
    public static Bitmap ApplyGamma(Bitmap bmp0, float gamma, float contrast)
    {
            
        Bitmap bmp1 = new Bitmap(bmp0.Width, bmp0.Height);
        using (Graphics g = Graphics.FromImage(bmp1))
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
                    {
                        new float[] {contrast, 0, 0, 0, 0},
                        new float[] {0,contrast, 0, 0, 0},
                        new float[] {0, 0, contrast, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
                                                   ColorAdjustType.Bitmap);
            attributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            g.DrawImage(bmp0, new Rectangle(0, 0, bmp0.Width, bmp0.Height),
                        0, 0, bmp0.Width, bmp0.Height, GraphicsUnit.Pixel, attributes);
        }
        return bmp1;
    }
