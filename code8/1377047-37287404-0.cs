    public static async Task Download(string folder, string file)
    {
        StorageFolder storeFolder = ApplicationData.Current.LocalFolder;
        CreationCollisionOption options = CreationCollisionOption.ReplaceExisting;
        StorageFile outputFile = await storeFolder.CreateFileAsync("temp.png", options);
                
        using (var dbx = new DropboxClient(yourAccessToken))
        {
              var response = await dbx.Files.DownloadAsync(downloadFolder);
              {
                   using (var file = await outputFile.OpenStreamForWriteAsync())
                   {
                        Stream imageStream = await response.GetContentAsStreamAsync();
                        CopyStream(imageStream, file);
                   }
              }
         }
    }
