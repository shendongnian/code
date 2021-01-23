    public async Task<bool> ValidateUrlAsync(string url)
    {
        using(var response = (HttpWebResponse)await WebRequest.Create(url).GetResponseAsync())
        return response.StatusCode == HttpStatusCode.Ok;
    }
