    ISupportedImageFormat format = new JpegFormat { Quality = 70 };
    using (MemoryStream inStream = new MemoryStream(_img))
    {
        using (MemoryStream outStream = new MemoryStream())
        {
            // Initialize the ImageFactory using the overload to preserve EXIF metadata.
            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
            {
                // Load, resize, set the format and quality and save an image.
                imageFactory.Load(inStream)
                            .AutoRotate()
                            .Resize(new ResizeLayer(new Size(width, height), resizeMode: resizeMode))
                            .Format(format)
                            .Save(outStream);
            }
            return outStream.ToArray();
        }
    }
