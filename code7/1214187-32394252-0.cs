    private static Bitmap PixelateLockBits(Bitmap image, Rectangle rectangle, int pixelateSize)
    {
        using (LockBitmap lockBitmap = new LockBitmap(image))
        {
            var width = image.Width;
            var height = image.Height;
    
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx += pixelateSize)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy += pixelateSize)
                {
                    Int32 offsetX = pixelateSize / 2;
                    Int32 offsetY = pixelateSize / 2;
    
                    // make sure that the offset is within the boundry of the image
                    while (xx + offsetX >= image.Width) offsetX--;
                    while (yy + offsetY >= image.Height) offsetY--;
    
                    // get the pixel color in the center of the soon to be pixelated area
                    Color pixel = lockBitmap.GetPixel(xx + offsetX, yy + offsetY);
    
                    // for each pixel in the pixelate size, set it to the center color
                    for (Int32 x = xx; x < xx + pixelateSize && x < image.Width; x++)
                        for (Int32 y = yy; y < yy + pixelateSize && y < image.Height; y++)
                            lockBitmap.SetPixel(x, y, pixel);
                }
            }
        }
        return image;
    }
