    using (MagickImage image = new MagickImage(response))
    {
      MagickGeometry size = new MagickGeometry(imgWidth, imgHeight);
      size.IgnoreAspectRatiomaintainAspectRatio;                                   
      image.Resize(size);
      using (Bitmap watermarkObj = Bitmap)Bitmap.FromFile("G:/Images/watermark.png"))
      {
        using (Bitmap imageObj = image.ToBitmap())
        {
          using (Graphics imageGraphics = Graphics.FromImage(imageObj))
          {
            Point point = new Point(image.Width - 118, image.Height - 29);
            imageGraphics.DrawImage(watermarkObj, point);
            imageObj.Save("G:/Images/ProcessedImage.JPG");
          }
        }
      }
    }
