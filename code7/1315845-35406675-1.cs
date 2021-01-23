    public async static Task<string> GetImageAsBase64Url(string url)
    {
        var credentials = new NetworkCredential(user, pw);
        using (var handler = new HttpClientHandler { Credentials = credentials })
        using (var client = new HttpClient(handler))
        {
            var bytes = await client.GetByteArrayAsync(url);
            return "image/jpeg;base64," + Convert.ToBase64String(bytes);
        }
    }
