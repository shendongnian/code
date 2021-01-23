    public async Task<string> SendPost(Model model)
    {
        var client = new HttpClient(); //You should extract this and reuse the same instance multiple times.
        var request = new HttpRequestMessage(HttpMethod.Post, Url + "api/foo");
        using(var content = new StringContent(Serialize(model), Encoding.UTF8, "application/json"))
        {
            request.Content = content;
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
