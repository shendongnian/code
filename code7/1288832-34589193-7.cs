    private async Task<BitmapImage> Base64StringToBitmap(string source)
    {
        var ims = new InMemoryRandomAccessStream();
        var bytes = Convert.FromBase64String(source);
        var dataWriter = new DataWriter(ims);
        dataWriter.WriteBytes(bytes);
        await dataWriter.StoreAsync();
        ims.Seek(0);
        var img = new BitmapImage();
        img.SetSource(ims);
        return img;
    }
    private async Task<string> ConvertStorageFileToBase64String(StorageFile imageFile)
    {
    var stream = await imageFile.OpenReadAsync();
    using (var dataReader = new DataReader(stream))
    {
        var bytes = new byte[stream.Size];
        await dataReader.LoadAsync((uint)stream.Size);
        dataReader.ReadBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
