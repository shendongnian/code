            private async Task SaveImageAsync(StorageFile inputFile, StorageFile outputFile)
        {
                Guid encoderId = BitmapEncoder.JpegEncoderId;
                using (IRandomAccessStream inputStream = await inputFile.OpenAsync(FileAccessMode.Read),
                           outputStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    outputStream.Size = 0;
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(inputStream);
                    BitmapTransform transform = new BitmapTransform();
                    double scalefactor = 0.2;  // 5 times smaller
                    transform.ScaledHeight = (uint)(decoder.PixelHeight * scalefactor);
                    transform.ScaledWidth = (uint)(decoder.PixelWidth * scalefactor);
                    transform.InterpolationMode = BitmapInterpolationMode.Fant;
                    BitmapPixelFormat format = decoder.BitmapPixelFormat;
                    BitmapAlphaMode alpha = decoder.BitmapAlphaMode;
                    PixelDataProvider pixelProvider = await decoder.GetPixelDataAsync(format, alpha, transform,
                        ExifOrientationMode.RespectExifOrientation, ColorManagementMode.ColorManageToSRgb);
                    byte[] pixels = pixelProvider.DetachPixelData();
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, outputStream);
                    encoder.SetPixelData(
                        format,
                        alpha,
                        (uint)((double)decoder.PixelWidth * scalefactor),
                        (uint)((double)decoder.PixelHeight * scalefactor),
                        decoder.DpiX,
                        decoder.DpiY,
                        pixels
                        );
                    await encoder.FlushAsync();
                }
        }
