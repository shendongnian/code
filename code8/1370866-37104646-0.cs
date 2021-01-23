    //Square
    if (image.Width == image.Height)
    {
        var newImage = new Bitmap(maxWidth, maxHeight);
        using (var graphics = Graphics.FromImage(newImage))
        {
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);
        }
        return newImage;
    }
