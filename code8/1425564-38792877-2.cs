    async Task<UIImage> getImageFromUrl(string uri)
    {
        using (var httpClient = new HttpClient())
        var imageBytes = await httpClient.GetByteArrayAsync(uri);
        var image = // create image from imageBytes;
        return image;
    }
