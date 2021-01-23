     private async void ConvertToGrayScale()
            {
                BitmapDecoder decoder = null;
                BitmapImage bitmapImage = new BitmapImage(new Uri(imageurl, UriKind.RelativeOrAbsolute));
               RandomAccessStreamReference rasr = RandomAccessStreamReference.CreateFromUri(bitmapImage.UriSource);
            
                using (IRandomAccessStreamWithContentType streamWithContent = await rasr.OpenReadAsync())
                {
                    decoder = await BitmapDecoder.CreateAsync(streamWithContent);
    
                    // Get the first frame
                    BitmapFrame bitmapFrame = await decoder.GetFrameAsync(0);
    
                    // Save the resolution (will be used for saving the file later)
                    //dpiX = bitmapFrame.DpiX;
                    //dpiY = bitmapFrame.DpiY;
    
                    // Get the pixels
                    PixelDataProvider dataProvider =
                        await bitmapFrame.GetPixelDataAsync(BitmapPixelFormat.Bgra8,
                                                            BitmapAlphaMode.Premultiplied,
                                                            new BitmapTransform(),
                                                            ExifOrientationMode.RespectExifOrientation,
                                                            ColorManagementMode.ColorManageToSRgb);
    
                    byte[] pixels = dataProvider.DetachPixelData();
    
                    // Create WriteableBitmap and set the pixels
                    WriteableBitmap srcBitmap = new WriteableBitmap((int)bitmapFrame.PixelWidth,
                                                                 (int)bitmapFrame.PixelHeight);
    
                    using (Stream pixelStream = srcBitmap.PixelBuffer.AsStream())
                    {
                        await pixelStream.WriteAsync(pixels, 0, pixels.Length);
                    }
    
                  
                    byte[] srcPixels = new byte[4 * srcBitmap.PixelWidth * srcBitmap.PixelHeight];
    
                    using (Stream pixelStream = srcBitmap.PixelBuffer.AsStream())
                    {
                        await pixelStream.ReadAsync(srcPixels, 0, srcPixels.Length);
                    }
    
                    // Create a destination bitmap and pixels array
                    WriteableBitmap dstBitmap =
                            new WriteableBitmap(srcBitmap.PixelWidth, srcBitmap.PixelHeight);
                    byte[] dstPixels = new byte[4 * dstBitmap.PixelWidth * dstBitmap.PixelHeight];
    
    
                    for (int i = 0; i < srcPixels.Length; i += 4)
                    {
                        double b = (double)srcPixels[i] / 255.0;
                        double g = (double)srcPixels[i + 1] / 255.0;
                        double r = (double)srcPixels[i + 2] / 255.0;
    
                        byte a = srcPixels[i + 3];
    
                        double e = (0.21 * r + 0.71 * g + 0.07 * b) * 255;
                        byte f = Convert.ToByte(e);
    
                        dstPixels[i] = f;
                        dstPixels[i + 1] = f;
                        dstPixels[i + 2] = f;
                        dstPixels[i + 3] = a;
    
                    }
    
                    // Move the pixels into the destination bitmap
                    using (Stream pixelStream = dstBitmap.PixelBuffer.AsStream())
                    {
                        await pixelStream.WriteAsync(dstPixels, 0, dstPixels.Length);
                    }
                    dstBitmap.Invalidate();
    
                    // Display the new bitmap
                   image.Source = dstBitmap;
                }
            }
