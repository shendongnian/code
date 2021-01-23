    public static async Task<string> Get(string url)
    {
        var client = getBaseHttpClient();
        var result = await client.GetAsync(url).ConfigureAwait(false);
        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadAsStringAsync();
        }
        return null;
    }
