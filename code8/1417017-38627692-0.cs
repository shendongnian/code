    public static async System.Threading.Tasks.Task<WriteableBitmap> CropImageAsync(InkCanvas source, int xOffset, int yOffset, int pixelWidth, int pixelHeight)
    {
        if (source.InkPresenter.StrokeContainer.GetStrokes().Count > 0)
        {
            using (var memStream = new InMemoryRandomAccessStream())
            {
                await source.InkPresenter.StrokeContainer.SaveAsync(memStream);
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(memStream);
                //pixelWidth and pixelHeight must less than the available pixel width and height
                if (pixelWidth > decoder.PixelWidth - xOffset || pixelHeight > decoder.PixelHeight - yOffset)
                {
                    return null;
                }
                BitmapTransform transform = new BitmapTransform();
                BitmapBounds bounds = new BitmapBounds();
                bounds.X = (uint)xOffset;
                bounds.Y = (uint)yOffset;
                bounds.Width = (uint)pixelWidth;
                bounds.Height = (uint)pixelHeight;
                transform.Bounds = bounds;
                // Get the cropped pixels within the bounds of transform.
                PixelDataProvider pix = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Bgra8, // WriteableBitmap uses BGRA format
                    BitmapAlphaMode.Straight,
                    transform,
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);
                byte[] pixels = pix.DetachPixelData();
                var cropBmp = new WriteableBitmap(pixelWidth, pixelHeight);
                // Stream the bytes into a WriteableBitmap
                using (Stream stream = cropBmp.PixelBuffer.AsStream())
                {
                    await stream.WriteAsync(pixels, 0, pixels.Length);
                }
                return cropBmp;
            }
        }
        else
        {
            return null;
        }
    }
