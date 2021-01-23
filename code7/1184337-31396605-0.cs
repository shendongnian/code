    ImageCodecInfo pngCodec = ImageCodecInfo.GetImageEncoders().Where(codec => codec.FormatID.Equals(ImageFormat.Png.Guid)).FirstOrDefault();
    if (pngCodec != null)
    {
        EncoderParameters parameters = new EncoderParameters();
        parameters.Param[0] = new EncoderParameter(Encoder.ColorDepth, 24); //8, 16, 24, 32 (base on your format)
        image.Save(stream, pngCodec, parameters);
    }
