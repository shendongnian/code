    using System.Drawing;
    const int size = 150;
    const int quality = 75;
    using (var image = new Bitmap(System.Drawing.Image.FromFile(inputPath)))
    {
        int width, height;
    if (image.Width > image.Height)
    {
        width = size;
        height = Convert.ToInt32(image.Height * size / (double)image.Width);
    }
    else
    {
        width = Convert.ToInt32(image.Width * size / (double)image.Height);
        height = size;
    }
    var resized = new Bitmap(width, height);
    using (var graphics = Graphics.FromImage(resized))
    {
        graphics.CompositingQuality = CompositingQuality.HighSpeed;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage(image, 0, 0, width, height);
        using (var output = File.Open(
            OutputPath(path, outputDirectory, SystemDrawing), FileMode.Create))
        {
            var qualityParamId = Encoder.Quality;
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);
            var codec = ImageCodecInfo.GetImageDecoders()
                .FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
            resized.Save(output, codec, encoderParameters);
        }
    }
    }
