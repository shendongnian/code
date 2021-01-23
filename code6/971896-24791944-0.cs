    public static async Task<string> Test(string token, Stream stream, string fileName)
    {
        HttpClient client = new HttpClient();
        MultipartFormDataContent content = new MultipartFormDataContent();
        content.Add(new StringContent(token), "token");
        content.Add(new StreamContent(stream), "image", fileName);
        var resp = await client.PostAsync("https://r.catchoom.com/v1/search", content);
        return await resp.Content.ReadAsStringAsync();
    }
