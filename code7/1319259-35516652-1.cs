    private static bool IsWhite(MagickImage image)
    {
      var white = MagickColors.White;
      using (var pixels = image.GetPixels())
      {
        foreach (var pixel in pixels)
        {
          var color = pixels.GetPixel(pixel.X, pixel.Y).ToColor();
          if (color != white)
            return false;
        }
      }
      return true;
    }
    static void Main(string[] args)
    {
      using (var image = new MagickImage(@"c:\folder\yourimage.png"))
      {
        if (IsWhite(image))
          Console.WriteLine("The image is all white");
      }
    }
