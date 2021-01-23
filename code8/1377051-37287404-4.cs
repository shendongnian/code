    public static async Task Upload(string filename, string filePath)
    {
        try
        {
            string TargetPath = "/data/" + filename + ".png";
            const int ChunkSize = 4096 * 1024;
            using (var dbx = new DropboxClient(yourAccessToken))
            {
                using (var fileStream = File.Open(filePath, FileMode.Open))
                {
                    if (fileStream.Length <= ChunkSize)
                    {
                        await dbx.Files.UploadAsync(TargetPath, null, false, null, false, body: fileStream);
                    }
                    else
                    {
                        MessageDialog dialog = new MessageDialog("File is too big");
                        await dialog.ShowAsync();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageDialog dialog = new MessageDialog("Error uploading file. " + ex.Message);
            await dialog.ShowAsync();
        }
    }
