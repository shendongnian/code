    public static async Task<BitmapImage> getImage(string fileName)
    {
        StorageFile file = await getFile(fileName);
        var image = await FileIO.ReadBufferAsync(file);
        return new BitmapImage(new Uri(file.Path));
    }
