    private static Image PlaceImageOverImage(Image background, Image overlay, int x, int y, float alpha)
    {
        using (Graphics graphics = Graphics.FromImage(background))
        {
            var cm = new ColorMatrix();
            cm.Matrix33 = alpha;
            var ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            graphics.DrawImage(
                overlay, 
                new Rectangle(x, y, overlay.Width, overlay.Height), 
                0, 0, overlay.Width, overlay.Height, 
                GraphicsUnit.Pixel, 
                ia);
        }
        return background;
    }
