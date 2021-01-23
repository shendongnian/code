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
