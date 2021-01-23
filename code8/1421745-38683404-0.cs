     private async Task<StorageFile> DownloadImagefromServer(string URI, string filename) {
            filename += ".png";
            var rootFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Citations365\\CoverPics", CreationCollisionOption.OpenIfExists);
            var coverpic = await rootFolder.CreateFileAsync(filename, CreationCollisionOption.FailIfExists);
            try {
                HttpClient client = new HttpClient();
                byte[] buffer = await client.GetByteArrayAsync(URI); // Download file
                using (Stream stream = await coverpic.OpenStreamForWriteAsync())
                    stream.Write(buffer, 0, buffer.Length); // Save
                return coverpic;
            } catch {
                return null;
            }
     }
