    public async Task WriteDataToFileAsync(string fileName, string content)
    {
    var folder = ApplicationData.Current.LocalFolder;
    var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
    
    using (var s = await file.OpenStreamForWriteAsync())
    {
        using (var writer = new StreamWriter(s))
        {
            await writer.WriteAsync(content);
        }
    } 
    }
