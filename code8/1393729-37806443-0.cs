     private async void StartDownload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri source = new Uri(inputURL);
                StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                    title.Text, CreationCollisionOption.GenerateUniqueName);
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destinationFile);
                // Attach progress and completion handlers.
                HandleDownloadAsync(download, true);
            }
            catch (Exception ex)
            {
                LogException("Download Error", ex);
            }
        }
