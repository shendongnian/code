    using (MagickImage image = new MagickImage(sourcePng))
    {
        image.Format = MagickFormat.Pcx;
        image.ColorType = ColorType.Palette;  // <----
        image.Write(targetPcx);
    }
