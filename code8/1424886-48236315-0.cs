    public static async Task<StorageFile> AsUIScreenShotFileAsync(this UIElement elememtName, string ReplaceLocalFileNameWithExtension)
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(ReplaceLocalFileNameWithExtension, CreationCollisionOption.ReplaceExisting);
            try
            {
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
                InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
                // Render to an image at the current system scale and retrieve pixel contents 
                await renderTargetBitmap.RenderAsync(elememtName);
                var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
                // Encode image to an in-memory stream 
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight,
                    DisplayInformation.GetForCurrentView().LogicalDpi,
                    DisplayInformation.GetForCurrentView().LogicalDpi, pixelBuffer.ToArray());
                await encoder.FlushAsync();
                //CreatingFolder
               // var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                RandomAccessStreamReference rasr = RandomAccessStreamReference.CreateFromStream(stream);
                var streamWithContent = await rasr.OpenReadAsync();
                byte[] buffer = new byte[streamWithContent.Size];
                await streamWithContent.ReadAsync(buffer.AsBuffer(), (uint)streamWithContent.Size, InputStreamOptions.None);
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                    {
                        using (DataWriter dataWriter = new DataWriter(outputStream))
                        {
                            dataWriter.WriteBytes(buffer);
                            await dataWriter.StoreAsync(); // 
                            dataWriter.DetachStream();
                        }
                        // write data on the empty file:
                        await outputStream.FlushAsync();
                    }
                    await fileStream.FlushAsync();
                }
               // await file.CopyAsync(folder, "tempFile.jpg", NameCollisionOption.ReplaceExisting);
            }
            catch (Exception ex)
            {
                Reporting.DisplayMessageDebugExemption(ex.Message);
            }
            return file;
        }
