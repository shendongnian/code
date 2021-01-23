    private async Task WriteToFile()
        {
            var myFile = await KnownFolders.MusicLibrary.CreateFileAsync(filename.Replace("---", " - ") + ".mp3", CreationCollisionOption.GenerateUniqueName);
            var fs = await myFile.OpenAsync(FileAccessMode.ReadWrite);
            IBuffer buffer = await response.Content.ReadAsBufferAsync();
            await fs.WriteAsync(buffer);
        }
