    private void ResizeImage(string path)
    {
        var image = System.Drawing.Image.FromFile(path);
        var widthAndHeightMax = 375D; //375px by 375 px. 
        var resizeImagePath = string.Concat(path.Substring(0, path.LastIndexOf('\\')), "\\Resized");
        var newImageName = path.Remove(0, path.LastIndexOf('\\') + 1);
        var newImageFullPath = string.Concat(resizeImagePath, "\\", newImageName);
        if (image.Width > widthAndHeightMax || image.Height > widthAndHeightMax || !File.Exists(newImageFullPath))
        {
            //Get Image Ratio
            var ratioX = widthAndHeightMax / image.Width;
            var ratioY = widthAndHeightMax / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new System.Drawing.Bitmap(newWidth, newHeight);
            var resizedImage = System.Drawing.Graphics.FromImage(newImage);
            resizedImage.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            resizedImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            resizedImage.DrawImage(image, 0, 0, newWidth, newHeight);
            if (!Directory.Exists(resizeImagePath))
            {
                Directory.CreateDirectory(resizeImagePath);
            }
            // Get an ImageCodecInfo object that represents the JPEG codec.
            var imageCodecInfo = ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);
            // Create an Encoder object for the Quality parameter.
            var encoder = Encoder.Quality;
            // Create an EncoderParameters object. 
            var encoderParameters = new EncoderParameters(1);
            // Save the image as a JPEG file with quality level.
            var encoderParameter = new EncoderParameter(encoder, 100L);
            encoderParameters.Param[0] = encoderParameter;
            //newImage.Save(newImageFullPath, imageCodecInfo, encoderParameters); throws GDI+ general error. normally security related
            using (var ms = new MemoryStream())
            {
                try
                {
                    using (var fs = new FileStream(string.Concat(resizeImagePath, "\\", newImageName), FileMode.Create, FileAccess.ReadWrite))
                    {
                        newImage.Save(ms, imageCodecInfo, encoderParameters);
                        var bytes = ms.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                catch
                {
                    //If the image exists, it may already be used by another process (which means it exists)
                }
            }
            productImage = newImageFullPath;
        }
    }
