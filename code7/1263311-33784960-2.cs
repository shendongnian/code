    public Image ChangeAlpha(Image img, int value)
    {
        if (value < 0 || value > 255)
            throw new Exception("value must be between 0 and 255");
        Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
        Graphics graphics = Graphics.FromImage(bmp);
        ColorMatrix colormatrix = new ColorMatrix();
        colormatrix.Matrix33 = value / 255f;
        ImageAttributes imgAttribute = new ImageAttributes();
        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
        graphics.Dispose();   // Releasing all resource used by graphics 
        return bmp;
    }
