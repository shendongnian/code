        ...
        await DownloadFile(service, uploadedFile.DownloadUrl);
        ...
        /// <summary>Downloads the media from the given URL.</summary>
        private async Task DownloadFile(DriveService service, string url)
        {
            var downloader = new MediaDownloader(service);
            var fileName = <PATH_TO_YOUR_FILE>
            using (var fileStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var progress = await downloader.DownloadAsync(url, fileStream);
                if (progress.Status == DownloadStatus.Completed)
                {
                    Console.WriteLine(fileName + " was downloaded successfully");
                }
                else
                {
                    Console.WriteLine("Download {0} was interpreted in the middle. Only {1} were downloaded. ",
                        fileName, progress.BytesDownloaded);
                }
            }
        }
