    public static async Task<T> DoPost<T>(string url, FormUrlEncodedContent formEnc)
    {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.PostAsync(url, formEnc))
        using (HttpContent content = response.Content)
        {
            var result = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
