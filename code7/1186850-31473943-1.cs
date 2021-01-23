    Task.Run(async () =>
            {
                var downloads = await BackgroundDownloader.GetCurrentDownloadsAsync();
                foreach (var download in downloads)
                {
                    CancellationTokenSource cts = new CancellationTokenSource();
                    download.AttachAsync().AsTask(cts.Token);
                    cts.Cancel();
                }
                var localFolder = ApplicationData.Current.LocalFolder;
                var files = await localFolder.GetFilesAsync();
                files = files.Where(x => x.Name.EndsWith("_")).ToList();
                foreach (StorageFile file in files)
                {
                    await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
                }
            });
