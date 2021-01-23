    using (MagickImage image = new MagickImage(response))
    {
      MagickGeometry size = new MagickGeometry(imgWidth, imgHeight);
      size.IgnoreAspectRatiomaintainAspectRatio;                                   
      image.Resize(size);
      using (MagickImage watermark = new MagickImage("G:/Images/watermark.png"))
      {
        image.Composite(watermark, image.Width - 118, image.Height - 29, CompositeOperator.Over);
        image.Write("G:/Images/ProcessedImage.JPG");
      }
    }
 
