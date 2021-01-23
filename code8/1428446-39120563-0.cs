    public async Task<string> SendRequestAsync(string url, string bearerToken, string contentType, string fileName)
    {
        var content = new StreamContent(File.OpenRead(fileName));
        content.Headers.TryAddWithoutValidation("Content-Type", contentType);
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var response = await httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
