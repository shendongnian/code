    // Create our image
    using (var image = new MagickImage())
    {
      image.Settings.BackgroundColor = MagickColors.Transparent;
      image.Read(data);
    }
