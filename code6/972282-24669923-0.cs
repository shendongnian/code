    static Bitmap CropImage(Image originalImage, Rectangle sourceRectangle, Rectangle destinationRectangle)
    {
        var croppedImage = new Bitmap(destinationRectangle.Width, destinationRectangle.Height);
        using (var graphics = Graphics.FromImage(croppedImage))
        {
            graphics.DrawImage(originalImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
        }
        return croppedImage;
    }
