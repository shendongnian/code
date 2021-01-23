    private static Bitmap ResizeImage(Image image, int? width, int? height)
    {
       var dimensions = GetImageDimensions(image.Width, image.Height, width, height);
       // We need to detect whether to resize or to crop
       bool mustCrop = newDimensions.Item3;
       // Initialize your SOURCE coordinates. By default, we copy
       // then entire image, resizing it
       int x = 0;
       int y = 0;
       int w = image.Width;
       int h = image.Height;
       // Adjust if we want to crop
       if (mustCrop)
       {
           x = (image.Width - newDimensions.Item1) / 2;
           y = (image.Height - newDimensions.Item2) / 2;
           w = newDimensions.Item1;
           h = newDimensions.Item2;
       }
       var destImage = new Bitmap(dimensions.Item1, dimensions.Item2);
       destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
       using (var graphics = Graphics.FromImage(destImage))
       {
           graphics.CompositingMode = CompositingMode.SourceCopy;
           graphics.CompositingQuality = CompositingQuality.HighQuality;
           graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
           graphics.SmoothingMode = SmoothingMode.HighQuality;
           graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
           using (var wrapMode = new ImageAttributes())
           {
               wrapMode.SetWrapMode(WrapMode.TileFlipXY);
               graphics.DrawImage(image, new Point(0,0), new Rectangle(x, y, w, h), GraphicsUnit.Pixel, wrapMode);
           }
       }
       return destImage;
