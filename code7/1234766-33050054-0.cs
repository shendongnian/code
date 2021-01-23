                    var decoder = await BitmapDecoder.CreateAsync(stream);
                    var pixels = await decoder.GetPixelDataAsync();
                    var file = await folder.CreateFileAsync($"{_oriFile.DisplayName}_{size}.png",CreationCollisionOption.GenerateUniqueName);
                    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, fileStream);
                        encoder.BitmapTransform.ScaledWidth = size;
                        encoder.BitmapTransform.ScaledHeight = size;
                        encoder.SetPixelData(
                            decoder.BitmapPixelFormat,
                            decoder.BitmapAlphaMode,
                            decoder.PixelWidth, decoder.PixelHeight,
                            decoder.DpiX, decoder.DpiY,
                            pixels.DetachPixelData());
                        encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
                        await encoder.FlushAsync();
                    }
