    public async Task<T> Get<T>(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-Mashape-Key", "AlZVYH30C9mshLPNM7KiE48aFfTHp1h3A31jsnmVPccxBzW5uB");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            var json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
