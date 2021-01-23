        async Task<RenderTargetBitmap> SaveToFileAsync(FrameworkElement uielement, StorageFile file)
        {
            if (file != null)
            {
                CachedFileManager.DeferUpdates(file);
                Guid encoderId = GetBitmapEncoder(file.FileType);
                try
                {
                    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        return await CaptureToStreamAsync(uielement, stream, encoderId);
                    }
                }
                catch (Exception ex)
                {
                    //DisplayMessage(ex.Message);
                }
                var status = await CachedFileManager.CompleteUpdatesAsync(file);
            }
            return null;
        }
    
            async Task<RenderTargetBitmap> CaptureToStreamAsync(FrameworkElement uielement, IRandomAccessStream stream, Guid encoderId)
        {
            try
            {
                var renderTargetBitmap = new RenderTargetBitmap();
                await renderTargetBitmap.RenderAsync(uielement);
                var pixels = await renderTargetBitmap.GetPixelsAsync();
                var logicalDpi = DisplayInformation.GetForCurrentView().LogicalDpi;
                var encoder = await BitmapEncoder.CreateAsync(encoderId, stream);
                encoder.SetPixelData(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Ignore,
                    (uint)renderTargetBitmap.PixelWidth,
                    (uint)renderTargetBitmap.PixelHeight,
                    logicalDpi,
                    logicalDpi,
                    pixels.ToArray());
                await encoder.FlushAsync();
                return renderTargetBitmap;
            }
            catch (Exception ex)
            {
                //DisplayMessage(ex.Message);
            }
            return null;
        }
