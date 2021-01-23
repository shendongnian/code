        ImageEncodingProperties imageEncodingProps = ImageEncodingProperties.CreateJpeg();
        InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream();
        await _mediaCapture.CapturePhotoToStreamAsync(imageEncodingProps, memoryStream);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(memoryStream);
            PixelDataProvider pixelProvider = await decoder.GetPixelDataAsync();
            byte[] pixels = pixelProvider.DetachPixelData();
            for (int index = 0; index < pixels.Length; index += 4)
            {
                Color color = Color.FromArgb(pixels[index + 3],
                                             pixels[index + 2],
                                             pixels[index + 1],
                                             pixels[index + 0]);
                HSL hsl = new HSL(color);
                hsl = new HSL(hsl.Hue, 1.0, hsl.Lightness);
                color = hsl.Color;
                pixels[index + 0] = color.B;
                pixels[index + 1] = color.G;
                pixels[index + 2] = color.R;
                pixels[index + 3] = color.A;
            }
            WriteableBitmap bitmap = new WriteableBitmap((int)decoder.PixelWidth, 
                                                         (int)decoder.PixelHeight);
            Stream pixelStream = bitmap.PixelBuffer.AsStream();
            await pixelStream.WriteAsync(pixels, 0, pixels.Length);
            bitmap.Invalidate();
            image.Source = bitmap;
